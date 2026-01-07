using Newtonsoft.Json; 

namespace ProductBrowserTest.Models.APIServices.Products.Models;

public class Dimensions
{
    [JsonProperty("width")]
    public decimal Width { get; set; }

    [JsonProperty("height")]
    public decimal Height { get; set; }

    [JsonProperty("depth")]
    public decimal Depth { get; set; }
}