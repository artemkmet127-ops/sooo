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
            new Product { Id = 1, Price = 100, Title = "Product 1", Model = "Category A", Feedbacks = 10 },
            new Product { Id = 2, Price = 200, Title = "Product 2", Model = "Category B", Feedbacks = 5 },
            new Product { Id = 3, Price = 150, Title = "Product 3", Model = "Category A", Feedbacks = 8 },
            new Product { Id = 4, Price = 300, Title = "Product 4", Model = "Category C", Feedbacks = 12 },
            new Product { Id = 5, Price = 250, Title = "Product 5", Model = "Category B", Feedbacks = 7 }
        };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SaveProduct(Product element)
        {
            products.Add(element);
            return RedirectToAction("AdminPanel");
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

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AdminPanel()
        {
            return View(products);
        }
    
        //public IActionResult Add()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (product == null)
                return BadRequest();

            // Генеруємо новий Id
            product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;

            products.Add(product);

            return RedirectToAction("AdminPanel");
        }
        public IActionResult Delete(int id)
        {
            var item = products.Find(x => x.Id == id);

            if (item == null)
                return NotFound(); // 404

            products.Remove(item);

            return RedirectToAction("AdminPanel");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
