using Microsoft.AspNetCore.Mvc;
using RetailInvetorySystem.Models;

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
    }
}
