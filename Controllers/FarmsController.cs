using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Moo_Arvelous_Coders.Controllers
{
    public class FarmsController : Controller
    {
        private readonly MooArvelousDbContext _context;

        public FarmsController(MooArvelousDbContext context)
        {
            _context = context;
        }

        // GET: Farms
        public async Task<IActionResult> Index()
        {
            var farms = await _context.Farms.ToListAsync();
            return View(farms);
        }

        // GET: Farms/Details/{id}
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farms.FirstOrDefaultAsync(f => f.FarmId == id);
            if (farm == null)
            {
                return NotFound();
            }

            return View(farm);
        }

        // GET: Farms/Create
        public IActionResult Create()
        {
            // Generate a new string ID for the view
            var model = new Farm
            {
                FarmId = Guid.NewGuid().ToString().Substring(0, 8)
            };
            return View(model);
        }

        // POST: Farms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Farm model)
        {
            if (ModelState.IsValid)
            {
                // Generate ID if missing (just in case)
                if (string.IsNullOrWhiteSpace(model.FarmId))
                {
                    model.FarmId = Guid.NewGuid().ToString().Substring(0, 8);
                }

                // Check for duplicate FarmName
                bool exists = await _context.Farms.AnyAsync(f => f.FarmName == model.FarmName);
                if (exists)
                {
                    ModelState.AddModelError("FarmName", "A farm with this name already exists.");
                    return View(model);
                }

                _context.Add(model);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Farm created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Farms/Edit/{id}
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farms.FindAsync(id);
            if (farm == null)
            {
                return NotFound();
            }
            return View(farm);
        }

        // POST: Farms/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Farm model)
        {
            if (id != model.FarmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Farm details updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FarmExists(model.FarmId))
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
            return View(model);
        }

        // GET: Farms/Delete/{id}
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farms.FirstOrDefaultAsync(f => f.FarmId == id);
            if (farm == null)
            {
                return NotFound();
            }
            return View(farm);
        }

        // POST: Farms/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var farm = await _context.Farms.FindAsync(id);
            if (farm != null)
            {
                _context.Farms.Remove(farm);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Farm deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FarmExists(string id)
        {
            return await _context.Farms.AnyAsync(f => f.FarmId == id);
        }
    }
}
