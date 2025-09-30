using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Data;
using Moo_Arvelous_Coders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace Moo_Arvelous_Coders.Controllers
{
    public class CattleController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;

        public CattleController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var cattleList = _context.Cattle
                .Include(c => c.CattleHealthRecords)
                .ToList();
            return View(cattleList);
        }

        public IActionResult Create(CattleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cattle = model.Cattle;
                var photo = model.Photo;
                var healthRecord = model.HealthRecord;

                // Database automatically assigns int IDs
                _context.Cattle.Add(cattle);
                _context.SaveChanges();

                if (healthRecord != null)
                {
                    healthRecord.CattleId = cattle.CattleId;
                    _context.CattleHealthRecords.Add(healthRecord);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> DeletePhoto(int id)
        {
            var photo = await _context.CattlePhotos.FindAsync(id);
            if (photo != null)
            {
                _context.CattlePhotos.Remove(photo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Create));
        }

        public IActionResult Edit(int id)
        {
            var cattle = _context.Cattle
                .Include(c => c.CattleHealthRecords)
                .FirstOrDefault(c => c.CattleId == id);

            if (cattle == null) return NotFound();

            var vm = new CattleCreateViewModel
            {
                Cattle = cattle,
                HealthRecord = cattle.CattleHealthRecords.FirstOrDefault() ?? new CattleHealthRecord()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CattleCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Cattle.Update(vm.Cattle);
                    _context.SaveChanges();

                    if (vm.HealthRecord != null && vm.HealthRecord.RecordId != 0)
                    {
                        vm.HealthRecord.CattleId = vm.Cattle.CattleId;
                        _context.CattleHealthRecords.Update(vm.HealthRecord);
                        _context.SaveChanges();
                    }

                    TempData["SuccessMessage"] = "Cattle and Health Record updated successfully!";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Cattle.Any(c => c.CattleId == vm.Cattle.CattleId))
                        return NotFound();
                    throw;
                }
            }

            return View(vm);
        }

        // GET: Cattle/Delete/{id}
        public IActionResult Delete(int id)
        {
            var cattle = _context.Cattle.FirstOrDefault(c => c.CattleId == id);
            if (cattle == null) return NotFound();

            return View(cattle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cattle = _context.Cattle
                .Include(c => c.CattleHealthRecords)
                .FirstOrDefault(c => c.CattleId == id);

            if (cattle != null)
            {
                if (cattle.CattleHealthRecords.Any())
                {
                    _context.CattleHealthRecords.RemoveRange(cattle.CattleHealthRecords);
                }

                _context.Cattle.Remove(cattle);
                _context.SaveChanges();
            }

            TempData["SuccessMessage"] = "Cattle deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
