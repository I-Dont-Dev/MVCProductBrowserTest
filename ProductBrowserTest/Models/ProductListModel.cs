namespace ProductBrowserTest.Models;

public class ProductListModel
{
    public List<ProductModel> Products { get; set; } = new();
    public bool ShowNextPageButton { get; set; }
    public bool ShowPreviousPageButton { get; set; }
}