using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductBrowserTest.Models;
using ProductBrowserTest.Models.APIServices.Products;

namespace ProductBrowserTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProductsService _productsService = new ProductsService();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task <IActionResult> Index(int page)
    {
        if (page == 0)
        {
            return RedirectToAction("Index", new { page = 1 });
        }
        
        ProductListModel? model = await _productsService.GetProductListAsync(page);
        if (model == null)
        {
            return View("ServiceError");
        }
        return View(model);
    }

    public async Task<IActionResult> Details(int id)
    {
        ProductModel? model = await _productsService.GetProductDetailsAsync(id);
        if (model == null)
        {
            return View("ResourceNotFound");
        }
        return View(model); 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}