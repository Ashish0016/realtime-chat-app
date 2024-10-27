using System.Net;

namespace Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public string Error { get; set; }
        public int StatusCode { get; } = (int)HttpStatusCode.BadRequest;

        public BadRequestException(string message) : base(message)
        {
            Error = message;
        }
    }
}
