using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Data;
using Moo_Arvelous_Coders.Models;
using Microsoft.EntityFrameworkCore;

namespace Moo_Arvelous_Coders.Controllers
{
    public class CattleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CattleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cattle/Index
        public IActionResult Index()
        {
            var cattleList = _context.Cattle.Include(c => c.CattleHealthRecords).ToList();
            return View(cattleList);
        }

        // GET: Cattle/Create
        public IActionResult Create()
        {
            var vm = new CattleCreateViewModel();
            return View(vm);
        }

        // POST: Cattle/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CattleCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Save Cattle
                _context.Cattle.Add(vm.Cattle);
                _context.SaveChanges();

                // Link HealthRecord to the newly saved Cattle
                if (vm.HealthRecord != null && !string.IsNullOrEmpty(vm.HealthRecord.RecordId))
                {
                    vm.HealthRecord.CattleId = vm.Cattle.CattleId;
                    _context.CattleHealthRecords.Add(vm.HealthRecord);
                    _context.SaveChanges();
                }

                TempData["SuccessMessage"] = "Cattle and Health Record saved successfully!";
                return RedirectToAction("Index");
            }

            // If validation fails, return the view with the same ViewModel
            return View(vm);
        }

        // GET: Cattle/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var cattle = _context.Cattle
                .Include(c => c.CattleHealthRecords)
                .FirstOrDefault(c => c.CattleId == id);

            if (cattle == null)
                return NotFound();

            var vm = new CattleCreateViewModel
            {
                Cattle = cattle,
                HealthRecord = cattle.CattleHealthRecords.FirstOrDefault() ?? new CattleHealthRecord()
            };

            return View(vm);
        }

        // POST: Cattle/Edit/{id}
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

                    if (vm.HealthRecord != null && !string.IsNullOrEmpty(vm.HealthRecord.RecordId))
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
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var cattle = _context.Cattle.FirstOrDefault(c => c.CattleId == id);
            if (cattle == null)
                return NotFound();

            return View(cattle);
        }

        // POST: Cattle/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var cattle = _context.Cattle
                .Include(c => c.CattleHealthRecords)
                .FirstOrDefault(c => c.CattleId == id);

            if (cattle != null)
            {
                // Delete related HealthRecords first
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


