using System.Diagnostics;
using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class HomeController (
        //Intanciar Servicios
        CategoryService _categoryService,
        ProductServices _productServices
        ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            var products = await _productServices.GetCatalogAsync();
            var catalog = new CatalogVM { Categories = categories, Products = products };

            return View(catalog);
        }


        //Filter by category
        public async Task<IActionResult> FilterByCategory(int id, string name)
        {
            var categories = await _categoryService.GetAllAsync();
            var products = await _productServices.GetCatalogAsync(categoryId:id);

            var catalog = new CatalogVM { Categories = categories, Products = products, filterBy=name};

            return View("Index", catalog);
        }

        //Search
        public async Task<IActionResult> FilterBySearch(string value)
        {
            var categories = await _categoryService.GetAllAsync();
            var products = await _productServices.GetCatalogAsync(search: value);

            var catalog = new CatalogVM { Categories = categories, Products = products, filterBy = $"Results for: {value}"};

            return View("Index",catalog);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
