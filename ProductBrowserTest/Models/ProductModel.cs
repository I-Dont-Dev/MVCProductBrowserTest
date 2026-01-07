namespace ProductBrowserTest.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Thumbnail { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string ShippingInformation { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<string> Tags { get; set; } = new();
    public List<string> Images { get; set; } = new();
}