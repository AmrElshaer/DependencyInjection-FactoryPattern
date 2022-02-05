using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIFactoryPattern.Exceptions
{
    public class NotSupportFormat : Exception
    {
        public NotSupportFormat() : base("Not Support This Format")
        {
        }
    }
}
