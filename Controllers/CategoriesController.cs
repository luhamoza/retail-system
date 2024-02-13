using Microsoft.AspNetCore.Mvc;
using RetailInvetorySystem.Models;

namespace SuperMarketInventorySystem.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }
        public IActionResult Edit(int? id)
        {
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            CategoriesRepository.updateCategory(category, category.CategoryId);
            return RedirectToAction(nameof(Index));
        }
    }
}
