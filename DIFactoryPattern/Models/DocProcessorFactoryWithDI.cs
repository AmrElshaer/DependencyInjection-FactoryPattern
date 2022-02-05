using DIFactoryPattern.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIFactoryPattern.Models
{
    public class DocProcessorFactoryWithDI : IDocumentProcessorFactory
    {
        private readonly IDictionary<string, Func<IDocumentProcessor>> _factories;
        public DocProcessorFactoryWithDI(IDictionary<string, Func<IDocumentProcessor>> factories)
        {
            _factories = factories;
        }
        public IDocumentProcessor Create(string type)
        {
            if (!_factories.TryGetValue(type, out var factory) || factory is null)
                throw new NotSupportFormat();
            return factory();
        }
    }
}
