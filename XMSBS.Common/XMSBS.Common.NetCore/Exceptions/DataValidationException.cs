using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.NetCore.Exceptions
{
    [Serializable]
    public class DataValidationException : Exception
    {
        private static string messageBase = "Uno o más parámetros son incorrectos";

        public string[] Messages { get; set; }

        public string FormatedMessages { get; set; }

        public DataValidationException()
            : base(DataValidationException.messageBase)
        {
        }

        public DataValidationException(string[] messages)
            : base(DataValidationException.messageBase)
        {
            this.Messages = messages;
            this.transformMessages();
        }

        public DataValidationException(string message)
            : base(message)
        {
            this.FormatedMessages = message;
        }

        public DataValidationException(string message, Exception inner)
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
