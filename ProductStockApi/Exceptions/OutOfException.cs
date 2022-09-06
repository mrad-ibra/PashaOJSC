using System;
using System.Runtime.Serialization;

namespace ProductStockApi.Exceptions
{
    [Serializable]
    internal class OutOfException : Exception
    {
        public OutOfException()
        {
        }

        public OutOfException(string message) : base(message)
        {
            message = "OutOfMessage";
        }

        public OutOfException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutOfException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

