using Microsoft.AspNetCore.Mvc;

namespace SmartCookbook.Controllers
{
    public class AddRecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateRecipe()
        {
            return View();
        }
    }
}
