using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIFactoryPattern.Models
{
    public class PdfProcessor : IDocumentProcessor
    {
        private readonly IPdfReader pdfReader;

        public PdfProcessor(IPdfReader pdfReader)
        {
            this.pdfReader = pdfReader;
        }

        public string Process()
        {
            return $"Process {pdfReader.GetPdfData()}";
        }
    }

    public interface IPdfReader
    {
        string GetPdfData();
    }

    public class PdfReader : IPdfReader
    {
        public string GetPdfData()
        {
            return "Pdf reader Provider";

        }
    }
}
