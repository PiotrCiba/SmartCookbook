using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartCookbook.Data;
using SmartCookbook.Models;

namespace SmartCookbook.Controllers
{
    public class SearchController : Controller
    {
        private readonly UserManager<SmartCookbookUser> _userManager;
        private readonly SignInManager<SmartCookbookUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public SearchController(
            UserManager<SmartCookbookUser> userManager,
            SignInManager<SmartCookbookUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult SearchRecipes(string searchString)
        {
            if(_context.Recipes== null)
            {
                return Problem("The Database does not contain any recipes.");
            }

            var recipes = _context.Recipes
                .Where(r => FuzzySharp.Fuzz.PartialRatio(r.Name, searchString) > 50 || 
                            FuzzySharp.Fuzz.PartialRatio(r.Description, searchString) > 50)
                .ToList();

            if(recipes.Count == 0)
            {
                return Problem("No recipes found.");
            }

            return View(recipes);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
