using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;

namespace UsingViewComponents.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult Index() => View(_productRepository.Products);

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            _productRepository.AddProduct(newProduct);
            return RedirectToAction("Index");
        }
    }
}
