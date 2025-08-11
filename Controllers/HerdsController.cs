using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Models;
using System;
using System.Threading.Tasks;

namespace Moo_Arvelous_Coders.Controllers
{
    public class HerdsController : Controller
    {
        private readonly MooArvelousDbContext _context;

        public HerdsController(MooArvelousDbContext context)
        {
            _context = context;
        }

        // GET: Herds
        public async Task<IActionResult> Index()
        {
            var herds = await _context.Herds.ToListAsync();
            return View(herds);
        }

        // GET: Herds/Create
        public IActionResult Create()
        {
            var model = new Herd
            {
                HerdId = Guid.NewGuid().ToString().Substring(0, 8)
            };
            return View(model);
        }

        // POST: Herds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Herd model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.HerdId))
                {
                    model.HerdId = Guid.NewGuid().ToString().Substring(0, 8);
                }

                _context.Herds.Add(model);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Herd created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Herds/Details/{id}
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var herd = await _context.Herds.FirstOrDefaultAsync(h => h.HerdId == id);
            if (herd == null) return NotFound();

            return View(herd);
        }

        // GET: Herds/Edit/{id}
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var herd = await _context.Herds.FindAsync(id);
            if (herd == null) return NotFound();

            return View(herd);
        }

        // POST: Herds/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Herd model)
        {
            if (id != model.HerdId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Herd details updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await HerdExists(model.HerdId))
                        return NotFound();
                    else
                        throw;
                }
            }
            return View(model);
        }

        // GET: Herds/Delete/{id}
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var herd = await _context.Herds.FirstOrDefaultAsync(h => h.HerdId == id);
            if (herd == null) return NotFound();

            return View(herd);
        }

        // POST: Herds/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var herd = await _context.Herds.FindAsync(id);
            if (herd != null)
            {
                _context.Herds.Remove(herd);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Herd deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> HerdExists(string id)
        {
            return await _context.Herds.AnyAsync(h => h.HerdId == id);
        }
    }
}
