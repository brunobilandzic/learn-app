using System;
using System.Net;
using System.Runtime.Serialization;

namespace API.Errors
{
    public class InternalServerException : AppException
    {
        public InternalServerException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = (int)statusCode;
        }
        public InternalServerException()
        {
        }

        public InternalServerException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        public InternalServerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InternalServerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}