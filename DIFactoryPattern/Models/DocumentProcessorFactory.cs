using DIFactoryPattern.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIFactoryPattern.Models
{
    public class DocumentProcessorFactory : IDocumentProcessorFactory
    {
        private readonly IPdfReader pdfReader;
        private readonly IWordReader wordReader;
        private readonly IOdtReader odtReader;

        public DocumentProcessorFactory(IPdfReader pdfReader, IWordReader wordReader, IOdtReader odtReader)
        {
            this.pdfReader = pdfReader;
            this.wordReader = wordReader;
            this.odtReader = odtReader;
        }

        public IDocumentProcessor Create(string type)
        {
            return type switch { 
             "pdf"=>new PdfProcessor(pdfReader),
             "odt"=>new OdtProcessor(odtReader),
             "doc"=>new WordProcessor(wordReader),
             _=> throw new NotSupportFormat()
            };
        }
    }
}
