using Microsoft.AspNetCore.Mvc;
using RetailInvetorySystem.Models;
using RetailInvetorySystem.ViewModels;

namespace RetailInvetorySystem.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel()
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(salesViewModel);
        }
        public IActionResult SalesProductPartial(int productId)
        {
            var product = ProductsRepository.GetProductById(productId);
            return PartialView("_SellProducts", product);
        }
        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Sell the product
            }

            var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
            salesViewModel.SelectedCategoryId = (product?.CategoryId == null) ? 0 : product.CategoryId.Value;
            salesViewModel.Categories = CategoriesRepository.GetCategories();

            return View("Index", salesViewModel);
        }
    }
}
