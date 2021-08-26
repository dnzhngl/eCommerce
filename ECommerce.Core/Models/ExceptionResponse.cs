using System.Net;

namespace EShop.Core.Models
{
    public class ExceptionResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ExceptionType { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}