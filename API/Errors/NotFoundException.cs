using System;
using System.Net;
using System.Runtime.Serialization;

namespace API.Errors
{
    public class NotFoundException : AppException
    {
        public NotFoundException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = (int)statusCode;
        }
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        
    }
}