using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIFactoryPattern.Models
{
    public class OdtProcessor: IDcoumentProcessor
    {
        private readonly IOdtReader odtReader;

        public OdtProcessor(IOdtReader odtReader)
        {
            this.odtReader = odtReader;
        }

        public string Process()
        {
            return $"Process {odtReader.GetOdtData()}";
        }
    }
    public class OdtReader: IOdtReader
    {
        public string GetOdtData()
        {
            return "Odt Reader Provider";
        }
    }
    public interface IOdtReader
    {
        string GetOdtData();
    }
}
