using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCookbook.Data;
using SmartCookbook.Data.Migrations;

namespace SmartCookbook.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("autocomplete")]
        public IActionResult Autocomplete(string term)
        {
            var ingredients = _context.Ingredients
                .Where(i => EF.Functions.Like(i.Name, $"%{term}%"))
                .Select(i => new { value = i.Name })
                .ToList(); 
            return Ok(ingredients);
        }

        [HttpGet("searchrecipes")]
        public IActionResult SearchRecipes([FromQuery] string[] ingredients)
        {
            var recipes = _context.Recipes
                .Where(r => r.Ingredients.Any(i => ingredients.Contains(i.Ingredient.Name.ToLower())))
                .ToList();

            return PartialView("_RecipeList", recipes);
        }
    }
}
