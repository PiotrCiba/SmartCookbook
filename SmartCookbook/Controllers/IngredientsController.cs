using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCookbook.Data;

namespace SmartCookbook.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string term)
        {
            var ingredients = await _context.Ingredients
                .Where(i => i.Name.Contains(term))
                .Select(i => new { id = i.Id, text = i.Name })
                .ToListAsync();

            return Json(ingredients);
        }
    }
}
