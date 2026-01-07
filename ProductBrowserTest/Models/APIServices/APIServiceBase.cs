using Newtonsoft.Json;

namespace ProductBrowserTest.Models.APIServices;

public class APIServiceBase : IAPIServiceBase
{
    const string DESERIALISATION_FAILURE = "Deserialisation Failure";
    const string SERVICE_ERROR = "Service Error";
    
    private readonly HttpClient HttpClient = new();

    public async Task<T?> SendGetRequestAsync<T>(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return default;
        }
        
        try
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Errors.Add(new() { StatusCode = response.StatusCode, Message = response.ReasonPhrase ?? string.Empty });
                return default;
            }

            string json = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                Errors.Add(new() { Message = DESERIALISATION_FAILURE });
                return default;
            }
        }
        catch
        {
            Errors.Add(new() { Message = SERVICE_ERROR });
            return default;
        }
    }

    public List<ErrorFeedback> Errors { get; } = new();
}