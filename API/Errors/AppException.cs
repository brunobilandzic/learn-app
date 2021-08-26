using System;
using System.Net;
using System.Runtime.Serialization;

namespace API.Errors
{
    public class AppException : System.Exception
    {
        public AppException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = (int)statusCode;
        }
        public AppException()
        {
        }

        public AppException(string message) : base(message)
        {
        }

        public AppException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public int StatusCode { get; set; }
    }
}