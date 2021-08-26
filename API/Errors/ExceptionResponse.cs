namespace API.Errors
{
    public class ExceptionResponse
    {
        public string Message { get; set; }
        public string Details { get; }
        public int StatusCode { get; set; }
        public ExceptionResponse(int statusCode, string message = null, string details = null)
        {
            Details = details;
            Message = message;
            StatusCode = statusCode;
        }
    }
}