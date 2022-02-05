using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIFactoryPattern
{
    public interface IDocumentProcessorFactory
    {
        IDcoumentProcessor Create(string type);
    }
}
