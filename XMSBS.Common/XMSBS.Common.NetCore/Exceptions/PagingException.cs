using System;

namespace XMSBS.Common.NetCore.Exceptions
{
    [Serializable]
    public class PagingException : Exception
    {
        public PagingException()
        {
        }

        public PagingException(string message)
            : base(message)
        {
        }

        public PagingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}