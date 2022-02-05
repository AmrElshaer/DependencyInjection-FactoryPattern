using DIFactoryPattern.Exceptions;
using DIFactoryPattern.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DIFactoryPattern.Test
{
    public class DocumentFormatWithDITest
    {
        private readonly IDocumentProcessorFactory factory;
        private readonly Mock<IPdfReader> pdfReader = new Mock<IPdfReader>();
        private readonly Mock<IWordReader> wordReader = new Mock<IWordReader>();
        private readonly Mock<IOdtReader> odtReader = new Mock<IOdtReader>();
        public DocumentFormatWithDITest()
        {
            SetUp();
            var factories = new Dictionary<string, Func<IDocumentProcessor>>()
            {
              ["pdf"]=()=>new PdfProcessor(pdfReader.Object),
              ["odt"]=()=>new OdtProcessor(odtReader.Object),
              ["doc"]=()=>new WordProcessor(wordReader.Object)

            };
            factory = new DocProcessorFactoryWithDI(factories);
        }

        [Theory]
        [InlineData("pdf", typeof(PdfProcessor))]
        [InlineData("odt", typeof(OdtProcessor))]
        [InlineData("doc", typeof(WordProcessor))]
        public void GetDocumentFormat_ValidFormat(string type, Type expectType)
        {
            var doc = factory.Create(type);
            Assert.IsType(expectType, doc);

        }
      
        [Fact]
        public void GetDocumentFormat_NotValidFormat_ExceptionNotSupportFormat()
        {
            Assert.Throws<NotSupportFormat>(() => factory.Create("dsfld"));
        }
        private void SetUp()
        {

            pdfReader.Setup(a => a.GetPdfData()).Returns("Pdf Data");
            wordReader.Setup(a => a.GetWordData()).Returns("Word Data");
            odtReader.Setup(a => a.GetOdtData()).Returns("Odt Data");
        }
    }
}
