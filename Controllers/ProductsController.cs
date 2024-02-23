using Microsoft.AspNetCore.Mvc;
using RetailInvetorySystem.Models;
using RetailInvetorySystem.ViewModels;

namespace SuperMarketInventorySystem.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts(loadCategory: true);
            return View(products);
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";
            var productViewModel = new ProductViewModel
            {
                Product = ProductsRepository.GetProductById(id.HasValue ? id.Value : 0),
                Categories = CategoriesRepository.GetCategories()
            };

            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
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
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "add";
            return View(productViewModel);
        }
    }
}
