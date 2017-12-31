using System;
using System.Collections.Generic;
using System.Text;

namespace HRIS.Common.Exceptions
{
    public class ValueObjectIsInvalidException : Exception
    {
        public ValueObjectIsInvalidException(string message) : base(message) { }
    }
}
