using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Data;
using Moo_Arvelous_Coders.Models;
using Microsoft.EntityFrameworkCore;

namespace Moo_Arvelous_Coders.Controllers
{
    public class HealthRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HealthRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ======================
        // SHOW HEALTH RECORDS PAGE
        // ======================
        public IActionResult Index(int cattleId)
        {
            // Make sure the cattle exists first
            var cattle = _context.Cattle.Find(cattleId);
            if (cattle == null)
                return NotFound();

            var existingRecords = _context.CattleHealthRecords
                .Where(h => h.CattleId == cattleId)
                .ToList();

            var viewModel = new HealthRecordViewModel
            {
                CattleId = cattleId,
                ExistingRecords = existingRecords
            };

            return View(viewModel);
        }


        // ======================
        // SAVE NEW OR UPDATED RECORD
        // ======================
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveHealthRecord(HealthRecordViewModel model)
        {
            // ---- SAFETY CHECK ----
            if (!_context.Cattle.Any(c => c.CattleId == model.CattleId))
            {
                ModelState.AddModelError("", "Invalid Cattle ID.");
                model.ExistingRecords = _context.CattleHealthRecords
                    .Where(h => h.CattleId == model.CattleId)
                    .ToList();
                return View("Index", model);
            }

            if (ModelState.IsValid)
            {
                if (model.CattleHealthRecord.RecordId == 0)
                {
                    model.CattleHealthRecord.CattleId = model.CattleId;
                    _context.CattleHealthRecords.Add(model.CattleHealthRecord);
                }
                else
                {
                    _context.CattleHealthRecords.Update(model.CattleHealthRecord);
                }

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Health record saved successfully!";

                return RedirectToAction("Index", new { cattleId = model.CattleId });
            }

            // reload list if invalid
            model.ExistingRecords = _context.CattleHealthRecords
                .Where(h => h.CattleId == model.CattleId)
                .ToList();

            return View("Index", model);
        }

    }
}
