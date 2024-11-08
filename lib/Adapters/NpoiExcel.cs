﻿using StringHelpers;
using SmartParser.Lib;


using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
#if WIN64
using Microsoft.Office.Interop.Excel;
#endif
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;



namespace SmartParser.Lib
{

    public class NpoiExcelAdapter : IAdapter
    {
        private XSSFWorkbook WorkBook;
        int SheetIndex = 0;
        int SheetCount;
        private Cell EmptyCell;
        private int MaxRowsToProcess;
        private string TempFileName;
#if WIN64
        string ConvertFile2TempXlsX(string filename)
        {
            Application excel = new Application();
            var doc = excel.Workbooks.Open(Path.GetFullPath(filename),ReadOnly:true);
            TempFileName = Path.GetTempFileName();
            Logger.Debug(string.Format("use {0} to store temp xlsx file", TempFileName));
            excel.DisplayAlerts = false;
            doc.SaveAs(
                Filename:TempFileName,
                FileFormat: XlFileFormat.xlOpenXMLWorkbook,
                ConflictResolution: XlSaveConflictResolution.xlLocalSessionChanges,
                WriteResPassword: "");
            doc.Close();
            excel.Quit();
            excel = null;
            return TempFileName;
        }
#endif
        public override bool IsExcel() { return true; }

        public NpoiExcelAdapter(string fileName, int maxRowsToProcess = -1)
        {
            DocumentFile = fileName;
            TempFileName = null;
            string extension = Path.GetExtension(fileName);
#if WIN64
            if (extension == ".xls")
            {
                fileName = ConvertFile2TempXlsX(fileName);
            }
#endif
            StreamReader file = new StreamReader(Path.GetFullPath(fileName));
            WorkBook = new XSSFWorkbook(file.BaseStream);
            //WorkBook = new XSSFWorkbook(Path.GetFullPath(fileName));
            EmptyCell = new Cell();
            MaxRowsToProcess = maxRowsToProcess;

            SheetCount = GetWorkSheetCount(out SheetIndex);
            WorkBook.SetActiveSheet(SheetIndex);
            TrimEmptyLines();
        }

        public static IAdapter CreateAdapter(string fileName, int maxRowsToProcess = -1)
        {
            return new NpoiExcelAdapter(fileName, maxRowsToProcess);
        }

        ~NpoiExcelAdapter()
        {
            WorkBook = null;
            if (TempFileName != null) File.Delete(TempFileName);
        }

        public override string GetDocumentPosition(int row, int col)
        {
            return GetDocumentPositionExcel(row, col);
        }


        public Cell GetCell(string cellIndex)
        {
            CellReference cellRef = new CellReference(cellIndex);
            return GetCell(cellRef.Row, cellRef.Col);
        }

        protected override List<Cell> GetCells(int row, int maxColEnd = MaxColumnsCount)
        {
            int index = 0;
            List<Cell> result = new List<Cell>();
            while (true)
            {
                var cell = GetCell(row, index);
                result.Add(cell);

                index += cell.MergedColsCount;
                if (index >= maxColEnd)
                {
                    break;
                }
            }

            return result;
        }
        public class CellAddress
        {
            public int row { get; set; }
            public int column { get; set; }
            public override int GetHashCode()
            {
                return row*100 + column; //maximal 100 columns in excel 
            }
            public override bool Equals(object obj)
            {
                return Equals(obj as CellAddress);
            }
            public bool Equals(CellAddress obj)
            {
                return obj != null && obj.row == this.row && obj.column == this.column;
            }
        }
        Dictionary<CellAddress, Cell> Cache = new Dictionary<CellAddress, Cell>();
        void InvalidateCache()
        {
            Cache.Clear();
        }
        public override Cell GetCell(int row, int column)
        {
            var address = new CellAddress{row=row, column=column};
            if (Cache.ContainsKey(address))
            {
                return Cache[address];
            }
            var c = GetCellWithoutCache(row, column);
            Cache[address] = c;
            return c;
        }
        Cell GetCellWithoutCache(int row, int column)
        {
            ISheet defaultSheet = WorkBook.GetSheetAt(SheetIndex);
            var currentRow = defaultSheet.GetRow(row);
            if (currentRow == null)
            {
                //null if row contains only empty cells
                return EmptyCell;
            }
            ICell cell = currentRow.GetCell(column);
            if (cell == null) return EmptyCell;
            
            bool isMergedCell = cell.IsMergedCell;
            int firstMergedRow;
            int mergedRowsCount;
            int mergedColsCount;
            if (isMergedCell)
            {
                CellRangeAddress mergedRegion = GetMergedRegion(defaultSheet, cell);
                firstMergedRow = mergedRegion.FirstRow;
                mergedRowsCount = mergedRegion.LastRow - mergedRegion.FirstRow + 1;
                mergedColsCount = mergedRegion.LastColumn - mergedRegion.FirstColumn + 1;
            }
            else
            {
                firstMergedRow = cell.RowIndex;
                mergedRowsCount = 1;
                mergedColsCount = 1;
                
            }

            var cellContents = cell.ToString();
            int cellWidth = 0;
            for (int i = 0; i < mergedColsCount; i++)
            {
                cellWidth += (int)defaultSheet.GetColumnWidth(column + i);
                //   to do npoi
            }

            return new Cell
            {
                IsMerged = isMergedCell,
                FirstMergedRow = firstMergedRow,
                MergedRowsCount = mergedRowsCount,
                MergedColsCount = mergedColsCount,
                // FIXME to init this property we need a formal definition of "header cell"
                IsEmpty = cellContents.IsNullOrWhiteSpace(),
                Text = cellContents,
                Row = row,
                Col = column,
                CellWidth = cellWidth
            };
            
        }

        void TrimEmptyLines()
        {
            int row = GetRowsCount() - 1; 
            while (row >= 0 && IsEmptyRow(row)) {
                MaxRowsToProcess = row;
                row--;
            }
        }

        public override int GetRowsCount()
        {
            int rowCount = WorkBook.GetSheetAt(SheetIndex).PhysicalNumberOfRows;
            if (MaxRowsToProcess != -1)
            {
                return Math.Min(MaxRowsToProcess, rowCount);
            }
            return rowCount;
        }

        public override int GetColsCount()
        {
            var firstSheet = WorkBook.GetSheetAt(SheetIndex);

            // firstSheet.GetRow(0) can fail, we have to use enumerators
            var iter = firstSheet.GetRowEnumerator();
            iter.MoveNext();
            IRow firstRow = (IRow)iter.Current;
            int firstLineColsCount = firstRow.Cells.Count;
            return firstLineColsCount;
        }


        private CellRangeAddress GetMergedRegion(ISheet sheet, ICell cell)
        {
            for (int i = 0; i < sheet.NumMergedRegions; i++)
            {
                var region = sheet.GetMergedRegion(i);
                if ((region.FirstRow <= cell.RowIndex && cell.RowIndex <= region.LastRow) &&
                    (region.FirstColumn <= cell.ColumnIndex && cell.ColumnIndex <= region.LastColumn))
                {
                    return region;
                }
            }

            throw new Exception($"Could not find merged region containing cell at row#{cell.RowIndex}, column#{cell.ColumnIndex}");
        }
        public override int GetWorkSheetCount()
        {
            int curIndex;
            return GetWorkSheetCount(out curIndex);
        }

        public int GetWorkSheetCount(out int curSheetIndex)
        {
            int worksheetCount = 0;
            curSheetIndex = -1;
            for (int index = 0; index <  WorkBook.NumberOfSheets; index++)
            {
                bool hidden = WorkBook.IsSheetHidden(index);
                var ws = WorkBook[index];
                if (!hidden && ws.LastRowNum > 0)
                {
                    if (curSheetIndex < 0)
                        curSheetIndex = 0;

                    worksheetCount++;
                }
            }
            if (worksheetCount == 0)
            {
                throw new Exception(String.Format("Excel sheet {0} has no visible worksheets", DocumentFile));
            }

            SheetIndex = curSheetIndex;
            InvalidateCache();
            return worksheetCount;
        }


        public override void SetCurrentWorksheet(int index)
        {
            int count = 0;
            int i = 0;
            bool found = false;
            for ( ; i < WorkBook.NumberOfSheets; i++)
            {
                bool hidden = WorkBook.IsSheetHidden(i);
                var ws = WorkBook[i];

                if (!hidden && ws.LastRowNum > 0)
                {
                    if (count == index)
                    {
                        SheetIndex = i;
                        found = true;
                        break;
                    }
                    count++;
                }
            }
            if (!found)
            {
                throw new SmartParserException("wrong  sheet index");
            }
            WorkBook.SetActiveSheet(SheetIndex);
            InvalidateCache();
            
        }

        public override string GetWorksheetName()
        {
            return WorkBook.GetSheetName(SheetIndex);
        }

        public override int? GetWorksheetIndex()
        {
            return SheetCount == 1 ? null : (int?)SheetIndex;
        }

        public override List<Cell> GetUnmergedRow(int row)
        {
            throw new Exception("unimplemented method");
        }

    }
}
