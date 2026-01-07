using ProductBrowserTest.Models.Adapters;
using ProductBrowserTest.Models.APIServices.Products.Models;

namespace ProductBrowserTest.Models.APIServices.Products;

public class ProductsService : APIServiceBase
{
    private const int MAX_PAGE_SIZE = ProductServiceStaticValues.MAX_PAGE_SIZE;
    private const string BASE_URL = "https://dummyjson.com";
    
    public async Task<ProductListModel?> GetProductListAsync(int page)
    {
        if (page < 1)
        {
            page = 1;
        }

        string requestUrl = $"{BASE_URL}/products?limit={MAX_PAGE_SIZE}&skip={(page - 1) * MAX_PAGE_SIZE}";

        ProductListResponse? response = await SendGetRequestAsync<ProductListResponse>(requestUrl);

        return response?.ToViewModel();
    }

    public async Task<ProductModel?> GetProductDetailsAsync(int id)
    {
        string requestUrl = $"{BASE_URL}/products/{id}";
        
        ProductDetailsResponse? response = await SendGetRequestAsync<ProductDetailsResponse>(requestUrl);

        return response?.ToViewModel();
    }
}