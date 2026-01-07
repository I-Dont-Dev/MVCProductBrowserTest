using ProductBrowserTest.Models.APIServices.Products;
using ProductBrowserTest.Models.APIServices.Products.Models;

namespace ProductBrowserTest.Models.Adapters;

public static class ProductsModelAdapter
{
    public static ProductListModel ToViewModel(this ProductListResponse apiModel)
    {
        return new()
        {
            ShowNextPageButton = apiModel.Total - apiModel.Skip >= ProductServiceStaticValues.MAX_PAGE_SIZE,
            ShowPreviousPageButton = apiModel.Skip >= 1,
            Products = apiModel.Products.Select(product => new ProductModel()
            {
                Id = product.Id,
                Thumbnail = product.Thumbnail,
                Title = product.Title,
                Price = product.Price,
                Tags = product.Tags
            }).ToList()
        };
    }

    public static ProductModel ToViewModel(this ProductDetailsResponse apiModel)
    {
        return new()
        {
            Id = apiModel.Id,
            Thumbnail = apiModel.Thumbnail,
            Title = apiModel.Title,
            Price = apiModel.Price,
            Tags = apiModel.Tags,
            ShippingInformation = apiModel.ShippingInformation,
            Images = apiModel.Images,
            Description = apiModel.Description
        };
    }
}