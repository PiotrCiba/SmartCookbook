using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartCookbook.Data;
using SmartCookbook.Models;

namespace SmartCookbook.Controllers
{
    public class CookingStepsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CookingStepsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CookingSteps
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CookingSteps.ToListAsync());
        }

        // GET: CookingSteps/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookingStep = await _context.CookingSteps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookingStep == null)
            {
                return NotFound();
            }

            return View(cookingStep);
        }

        // GET: CookingSteps/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CookingSteps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Description,Duration,Unit")] CookingStep cookingStep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cookingStep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cookingStep);
        }

        // GET: CookingSteps/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookingStep = await _context.CookingSteps.FindAsync(id);
            if (cookingStep == null)
            {
                return NotFound();
            }
            return View(cookingStep);
        }

        // POST: CookingSteps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Duration,Unit")] CookingStep cookingStep)
        {
            if (id != cookingStep.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cookingStep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookingStepExists(cookingStep.Id))
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
            return View(cookingStep);
        }

        // GET: CookingSteps/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookingStep = await _context.CookingSteps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookingStep == null)
            {
                return NotFound();
            }

            return View(cookingStep);
        }

        // POST: CookingSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cookingStep = await _context.CookingSteps.FindAsync(id);
            if (cookingStep != null)
            {
                _context.CookingSteps.Remove(cookingStep);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CookingStepExists(int id)
        {
            return _context.CookingSteps.Any(e => e.Id == id);
        }
    }
}
