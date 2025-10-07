using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Data;
using Moo_Arvelous_Coders.Models;
using System.Threading.Tasks;

namespace Moo_Arvelous_Coders.Controllers
{
    public class HerdsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HerdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Herds
        public async Task<IActionResult> Index()
        {
            var herds = await _context.Herds.ToListAsync();
            ViewBag.Herds = herds;
            return View(herds);
        }

        // GET: Herds/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var herd = await _context.Herds
                .Include(h => h.HerdComments)// Include comments
                .Include(h => h.Cattles)// Load all cattle in this herd
                .FirstOrDefaultAsync(h => h.HerdId == id);

            if (herd == null) return NotFound();

            return View(herd);
        }

        // GET: Herds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Herds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Herd model)
        {
            ModelState.Remove("Cattles");
            ModelState.Remove("FarmId");
            ModelState.Remove("FarmerId");

            if (ModelState.IsValid)
            {
                _context.Herds.Add(model);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Herd created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Herds/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var herd = await _context.Herds.FindAsync(id);
            if (herd == null) return NotFound();
            return View(herd);
        }

        // POST: Herds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Herd model)
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

        // GET: Herds/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var herd = await _context.Herds.FirstOrDefaultAsync(h => h.HerdId == id);
            if (herd == null) return NotFound();

            return View(herd);
        }

        // POST: Herds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        private async Task<bool> HerdExists(int id)
        {
            return await _context.Herds.AnyAsync(h => h.HerdId == id);
        }
    }
}
