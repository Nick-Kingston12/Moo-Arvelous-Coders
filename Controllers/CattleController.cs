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

        // ======================
        // LIST ALL CATTLE
        // ======================
        public IActionResult Index()
        {
            var cattleList = _context.Cattle.ToList();
            return View(cattleList);
        }

        // ======================
        // CREATE CATTLE
        // ======================
        [HttpGet]
        [HttpGet]
        public IActionResult Create()
        {
            // Get all herds to populate dropdown
            var herds = _context.Herds.ToList();
            ViewBag.Herds = herds;

            return View(new Cattle());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cattle cattle)
        {
            if (ModelState.IsValid)
            {
                _context.Cattle.Add(cattle);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Cattle created successfully!";
                return RedirectToAction(nameof(Index));
            }

            // Repopulate the herds dropdown if model is invalid
            ViewBag.Herds = _context.Herds.ToList();
            return View(cattle);
        }


        // ======================
        // VIEW CATTLE DETAILS
        // ======================
        public IActionResult Details(int id)
        {
            var cattle = _context.Cattle
                .Include(c => c.CattleHealthRecords)
                .FirstOrDefault(c => c.CattleId == id);

            if (cattle == null)
                return NotFound();

            return View(cattle);
        }

        // ======================
        // EDIT CATTLE
        // ======================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cattle = _context.Cattle.Find(id);
            if (cattle == null)
                return NotFound();

            return View(cattle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cattle cattle)
        {
            if (ModelState.IsValid)
            {
                _context.Cattle.Update(cattle);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Cattle updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(cattle);
        }

        // ======================
        // DELETE CATTLE
        // ======================
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cattle = _context.Cattle.FirstOrDefault(c => c.CattleId == id);
            if (cattle == null)
                return NotFound();

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
                TempData["SuccessMessage"] = "Cattle deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }

        // ======================
        // LINK TO HEALTH RECORDS PAGE
        // ======================
        public IActionResult HealthRecords(int id)
        {
            // Redirects to the HealthRecords controller/view
            return RedirectToAction("Index", "HealthRecords", new { cattleId = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadPhoto(int cattleId, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                // 1. Generate a unique filename
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(photo.FileName)}";

                // 2. Combine path to wwwroot/images/cattle
                var filePath = Path.Combine(_env.WebRootPath, "images", "cattle", fileName);

                // 3. Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                // 4. Save the photo record to the database
                var cattlePhoto = new CattlePhoto
                {
                    CattleId = cattleId,
                    PhotoUrl = $"/images/cattle/{fileName}"
                };
                _context.CattlePhotos.Add(cattlePhoto);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Photo uploaded successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Please select a photo to upload.";
            }

            return RedirectToAction("Edit", new { id = cattleId });
        }

    }
}
