using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.Exceptions
{
    [Serializable]
    public class DataValidationException : Exception
    {
        public DataValidationException()
        {
        }

        public DataValidationException(string message)
            : base(message)
        {
        }

        public DataValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
