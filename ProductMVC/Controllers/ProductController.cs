using Microsoft.AspNetCore.Mvc;
using ProductMVC.Models;

namespace ProductMVC.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product>? products { get; set; }

        static ProductController()
        {
            products = new List<Product>();
            for (int i = 1; i <= 20; i++)
            {
                products.Add(new Product
                {
                    Id = i,
                    Name = "Product " + i,
                    Price = 10
                });
            }
        }
        public IActionResult GetAllProduct()
        {
            return View(products);
        }

        public IActionResult GetProductById(int id)
        {
            var product = products?.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        public IActionResult DeleteProductById(int id)
        {
            var product = products?.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products?.Remove(product);
            }
            return RedirectToAction("GetAllProduct");
        }
    }
}
