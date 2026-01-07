using System.Net;

namespace ProductBrowserTest.Models.APIServices;

public class ErrorFeedback
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}