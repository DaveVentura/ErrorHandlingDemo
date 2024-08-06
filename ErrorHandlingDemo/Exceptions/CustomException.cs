namespace ErrorHandlingDemo.Exceptions
{
    public class CustomException : Exception
    {
        public override string Message { get; }
        public int StatusCode { get; set; }

        public CustomException(string message, int statusCode = StatusCodes.Status500InternalServerError)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
