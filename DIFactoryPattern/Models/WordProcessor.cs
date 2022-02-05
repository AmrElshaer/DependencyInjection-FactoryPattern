using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIFactoryPattern.Models
{
    public class WordProcessor:IDocumentProcessor
    {
        private readonly IWordReader wordReader;

        public WordProcessor(IWordReader wordReader)
        {
            this.wordReader = wordReader;
        }

        public string Process()
        {
            return $"Process {wordReader.GetWordData()}";
        }
    }
    public class WordReader: IWordReader
    {
        public string GetWordData()
        {
            return "Word Reader Provider";
        }
    }
    public interface IWordReader
    {
        string GetWordData();
    }
}
