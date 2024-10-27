using System.Net;

namespace Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Error { get; set; } = string.Empty;
        public int StatusCode { get; } = (int)HttpStatusCode.NotFound;
        public NotFoundException(string error) : base()
        {
            Error = !string.IsNullOrWhiteSpace(error) ? error : "One of the entities from request object was not found in database.";
        }
    }
}
