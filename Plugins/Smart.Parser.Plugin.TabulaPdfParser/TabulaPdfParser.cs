using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Smart.Parser.Plugin.TabulaPdfParser
{
    public class TabulaPdfParser : DocumentParser
    {
        public override string Name { get; } = "Tabula PDF Tables Parser";

        public override Task<string> Parse(FileInfo file)
        {
            var document = PdfReader.Open(file.FullName, PdfDocumentOpenMode.Import);
            return null;
        }
    }
}
