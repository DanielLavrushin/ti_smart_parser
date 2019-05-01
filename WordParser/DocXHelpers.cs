﻿using System;
using System.Text;

using Xceed.Words.NET;

using TI.Declarator.ParserCommon;


namespace TI.Declarator.WordParser
{
    public static class DocXHelpers
    {
        public static string GetText(this Cell c, bool Unbastardize = false)
        {
            var res = new StringBuilder();
            foreach (var p in c.Paragraphs)
            {
                res.Append(p.Text);
                res.Append("\n");
            }

            if (Unbastardize)
            {
                return res.ToString().RemoveStupidTranslit().Replace("  ", " ").Trim();
            }
            return res.ToString();
        }

        /// <summary>
        /// Get text representation for given row. Used mostly for debug purposes
        /// </summary>
        /// <param name="r"></param>
        public static string Stringify(this Xceed.Words.NET.Row r)
        {
            var resSb = new StringBuilder();

            foreach (var c in r.Cells)
            {
                resSb.Append(c.GetText());
                resSb.Append(" | ");
            }

            return resSb.ToString();
        }
    }
}
