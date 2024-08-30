using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartCookbook.Data;
using SmartCookbook.Models;
using System.Text.Json.Nodes;

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

        public List<Recipe> Recipes(string searchString)
        {
            if(_context.Recipes== null)
            {
                return new List<Recipe>();
            }

            var recipes = _context.Recipes
                .Where(r => (FuzzySharp.Fuzz.PartialRatio(r.Name, searchString) > 50 || 
                            FuzzySharp.Fuzz.PartialRatio(r.Description, searchString) > 50) && 
                            r.Private == false)
                .ToList();

            return recipes;
        }

        [HttpPost]
        public IActionResult SearchRecipes(string searchString)
        {
            var recipes = Recipes(searchString);
            return Json(recipes);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
