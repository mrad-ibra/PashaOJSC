using System;
using System.Runtime.Serialization;

namespace ProductStockApi.Exceptions
{
    public class InvalidProductException
    {
        [Serializable]
        internal class InvalidProductIdException : Exception
        {
            public InvalidProductIdException()
            {

            }

            public InvalidProductIdException(string message) : base(message)
            {
                message = "Product Id is Invalid";
            }

            public InvalidProductIdException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected InvalidProductIdException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
