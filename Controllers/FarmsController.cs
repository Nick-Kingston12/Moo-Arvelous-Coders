using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Data;
using Moo_Arvelous_Coders.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Moo_Arvelous_Coders.Controllers
{
    public class FarmsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmsController( ApplicationDbContext context)
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
        public async Task<IActionResult> Details(int id)
        {
            var farm = await _context.Farms.FirstOrDefaultAsync(f => f.FarmId == id);
            if (farm == null) return NotFound();
            return View(farm);
        }

        // GET: Farms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Farm model)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Edit(int id)
        {
            var farm = await _context.Farms.FindAsync(id);
            if (farm == null) return NotFound();
            return View(farm);
        }

        // POST: Farms/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Farm model)
        {
            if (id != model.FarmId) return NotFound();

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
        public async Task<IActionResult> Delete(int id)
        {
            var farm = await _context.Farms.FirstOrDefaultAsync(f => f.FarmId == id);
            if (farm == null) return NotFound();
            return View(farm);
        }

        // POST: Farms/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        private async Task<bool> FarmExists(int id)
        {
            return await _context.Farms.AnyAsync(f => f.FarmId == id);
        }
    }
}
