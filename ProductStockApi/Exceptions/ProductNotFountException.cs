using System;
using System.Runtime.Serialization;

namespace ProductStockApi.Exceptions
{
    [Serializable]
    internal class ProductNotFountException : Exception
    {
        public ProductNotFountException()
        {
        }

        public ProductNotFountException(string message) : base(message)
        {
            message = "Product Not Found On This Stock";
        }

        public ProductNotFountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductNotFountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
