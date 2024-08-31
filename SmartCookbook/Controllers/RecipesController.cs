using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartCookbook.Data;
using SmartCookbook.Models;
using FuzzySharp;

namespace SmartCookbook.Controllers
{
    public class RecipesController : Controller
    {
		private readonly UserManager<SmartCookbookUser> _userManager;
		private readonly SignInManager<SmartCookbookUser> _signInManager;
		private readonly ApplicationDbContext _context;

        public RecipesController(
			UserManager<SmartCookbookUser> userManager,
			SignInManager<SmartCookbookUser> signInManager,
			ApplicationDbContext context)
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index(string? searchString)
        {
            var recipes = _context.Recipes.Where(r => r.Private == false);
            if (string.IsNullOrEmpty(searchString))
            {
                return View(recipes);
            }

            var results = recipes.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) 
                                    || s.Description.ToUpper().Contains(searchString.ToUpper()))
                                    .ToList();

            if (Request.Headers["x-requested-with"] == "XMLHttpRequest")
            {
                return PartialView("_RecipeList", results);
            }

            return View(results);
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.Include(r => r.Ingredients).ThenInclude(ii => ii.Ingredient)
                                            .Include(r => r.Steps)
                                            .Include(r => r.Ratings)
                                            .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Author,Private,UploadDate,Name,ImagePath,Description,Ingredients,Steps")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                Recipe temp = recipe;
                temp.Author = _userManager.GetUserName(User);
                temp.UploadDate = DateTime.Now;
                _context.Add(temp);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = temp.Id });
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.Include(r => r.Ingredients).ThenInclude(ii => ii.Ingredient)
                                            .Include(r => r.Steps)
                                            .FirstOrDefaultAsync(m => m.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (recipe.Author != user.UserName)
            {
                return Unauthorized();
            }

            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Author,Private,UploadDate,Name,ImagePath,Description,Ingredients,Steps")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);

            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
