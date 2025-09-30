using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static List<Product> products = new()
        {
            new Product { Id = 1, Price = 100, Title = "Product 1", Category = "Category A", Quantity = "10" },
            new Product { Id = 2, Price = 200, Title = "Product 2", Category = "Category B", Quantity = "5" },
            new Product { Id = 3, Price = 150, Title = "Product 3", Category = "Category A", Quantity = "8" },
            new Product { Id = 4, Price = 300, Title = "Product 4", Category = "Category C", Quantity = "12" },
            new Product { Id = 5, Price = 250, Title = "Product 5", Category = "Category B", Quantity = "7" }
        };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult AdminPanel()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {

            return RedirectToAction("AdminPanel");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
