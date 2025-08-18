using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Data;
using Moo_Arvelous_Coders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

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
            var cattleList = _context.Cattle.Include(c => c.CattleHealthRecords).ToList();
            return View(cattleList);
        }

        public IActionResult Create()
        {
            var vm = new CattleCreateViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CattleCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {

                _context.Cattle.Add(vm.Cattle);
                _context.SaveChanges();

   
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CattleCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.Cattle.CattleId))
                model.Cattle.CattleId = Guid.NewGuid().ToString();

            if (string.IsNullOrWhiteSpace(model.Photo.PhotoId))
                model.Photo.PhotoId = Guid.NewGuid().ToString();

            model.Photo.CattleId = model.Cattle.CattleId;

            if (model.PhotoFile != null && model.PhotoFile.Length > 0)
            {
                var uploadsRoot = Path.Combine(_env.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsRoot))
                    Directory.CreateDirectory(uploadsRoot);

                var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(model.PhotoFile.FileName);
                var fullPath = Path.Combine(uploadsRoot, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.PhotoFile.CopyToAsync(stream);
                }

                model.Photo.PhotoUrl = "/uploads/" + fileName;
            }

            _context.Cattle.Add(model.Cattle);                    
            _context.CattlePhotos.Add(model.Photo);               

            if (!string.IsNullOrWhiteSpace(model.HealthRecord?.TreatmentType) ||
                !string.IsNullOrWhiteSpace(model.HealthRecord?.Details))
            {
                if (string.IsNullOrWhiteSpace(model.HealthRecord.RecordId))
                    model.HealthRecord.RecordId = Guid.NewGuid().ToString();

                model.HealthRecord.CattleId = model.Cattle.CattleId;
                _context.CattleHealthRecords.Add(model.HealthRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index"); // or wherever you want to go after create
        }
    }
}


