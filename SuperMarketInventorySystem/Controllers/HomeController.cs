using Microsoft.AspNetCore.Mvc;

namespace SuperMarketInventorySystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
