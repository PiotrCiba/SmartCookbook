using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using SmartCookbook.Data;
using SmartCookbook.Models;

namespace SmartCookbook.Controllers
{
    public class RatingsController : Controller
    {

        private readonly UserManager<SmartCookbookUser> _userManager;
        private readonly SignInManager<SmartCookbookUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public RatingsController(
            UserManager<SmartCookbookUser> userManager,
            SignInManager<SmartCookbookUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult RateRecipe(int recipeId, int? rating, string? comment)
        {
            var recipe = _context.Recipes.Find(recipeId);
            if (recipe == null)
            {
                return NotFound();
            }

            if (rating == null || rating < 1 || rating > 5)
            {
                return BadRequest();
            }

            if(!_signInManager.IsSignedIn(User))
            {
                return Unauthorized();
            }

            var ratingToAdd = new Rating
            {
                Recipe = recipe,
                RecipeId = recipeId,
                UserName = _userManager.GetUserName(User),
                Date = DateTime.Now,
                RatingValue = rating.Value,
                Comment = comment ?? string.Empty
            };

            recipe.Ratings.Add(ratingToAdd);

            _context.Recipes.Update(recipe);
            _context.SaveChanges();

            return RedirectToAction("Details", "Recipes", new { area = "Recipes" , id = recipeId });
        }

        public IActionResult DeleteRating(int ratingId)
        {
            var rating = _context.Ratings.Find(ratingId);

            if (rating == null) {
                return NotFound();
            }

            var recipeId = rating.RecipeId;
            var recipe = _context.Recipes.Find(recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            if(!_signInManager.IsSignedIn(User))
            {
                return Unauthorized();
            }

            if (rating.UserName != _userManager.GetUserName(User))
            {
                return Unauthorized();
            }

            recipe.Ratings.Remove(rating);

            _context.Update(recipe);
            _context.SaveChanges();

            return RedirectToAction("Details", "Recipes", new { area = "Recipes", id = recipeId });
        }
    }
}
