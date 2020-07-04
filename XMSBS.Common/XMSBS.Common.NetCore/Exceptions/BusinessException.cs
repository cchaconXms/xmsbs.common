using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.NetCore.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {

        private static string messageBase = "Una o más condiciones no se han cumplido";

        public string[] Messages { get; set; }

        public string FormatedMessages { get; set; }

        public BusinessException()
            : base(BusinessException.messageBase)
        {
        }

        public BusinessException(string[] messages)
            : base(BusinessException.messageBase)
        {
            this.Messages = messages;
            this.transformMessages();
        }

        public BusinessException(string message)
            : base(message)
        {
            this.FormatedMessages = message;
        }

        public BusinessException(string message, Exception inner)
            : base(message, inner)
        {
            this.FormatedMessages = message;
        }

        private void transformMessages()
        {
            this.FormatedMessages = "";
            foreach (string message in this.Messages)
                this.FormatedMessages = this.FormatedMessages + message + Environment.NewLine;
        }

    }
}
