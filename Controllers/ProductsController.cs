using Microsoft.AspNetCore.Mvc;
using RetailInvetorySystem.Models;

namespace SuperMarketInventorySystem.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts();
            return View(products);
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";

            var product = ProductsRepository.GetProductById(id.HasValue ? id.Value : 0);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(product.ProductId, product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public IActionResult Delete(int productId)
        {
            ProductsRepository.DeleteProduct(productId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            return View("Add");
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
