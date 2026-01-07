namespace ProductBrowserTest.Models.APIServices;

internal interface IAPIServiceBase
{
    public Task<T?> SendGetRequestAsync<T>(string url);
    public List<ErrorFeedback> Errors { get; }
}