using DIFactoryPattern.Exceptions;
using DIFactoryPattern.Models;
using Moq;
using System;
using Xunit;

namespace DIFactoryPattern.Test
{
    public class DocumentFormatTest
    {
        private readonly Mock<IPdfReader> pdfReader=new Mock<IPdfReader>();
        private readonly Mock<IWordReader> wordReader=new Mock<IWordReader>();
        private readonly Mock<IOdtReader> odtReader=new Mock<IOdtReader>();
        private readonly IDocumentProcessorFactory factory;
        public DocumentFormatTest()
        {
            SetUp();
            this.factory = new DocumentProcessorFactory(pdfReader.Object, wordReader.Object, odtReader.Object);
            
        }
        [Theory]
        [InlineData("pdf", typeof(PdfProcessor))]
        [InlineData("odt", typeof(OdtProcessor))]
        [InlineData("doc", typeof(WordProcessor))]
        public void GetDocumentFormat_ValidFormat(string type,Type expectType)
        {
          
            var res= factory.Create(type);
            Assert.IsType(expectType, res);
        }
        [Fact]
        public void GetDocumentFormat_NotValidFormat_ExceptionNotSupportFormat()
        {
            Assert.Throws<NotSupportFormat>(()=> factory.Create("dsfld"));
        }
        [Theory]
        [InlineData("pdf", "Process Pdf Data")]
        [InlineData("odt", "Process Odt Data")]
        [InlineData("doc", "Process Word Data")]
        public void GetDocumentFormat_ValidFormat_ReturnData(string type, string expectData)
        {
            var doc = factory.Create(type);
            Assert.Equal(expectData, doc.Process());

        }
        private void SetUp()
        {
           
            pdfReader.Setup(a => a.GetPdfData()).Returns("Pdf Data");
            wordReader.Setup(a => a.GetWordData()).Returns("Word Data");
            odtReader.Setup(a => a.GetOdtData()).Returns("Odt Data");
        }
    }
}
