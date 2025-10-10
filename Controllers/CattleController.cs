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
        public async Task<IActionResult> Create(Cattle cattle, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                // 1. Add cattle record first
                _context.Cattle.Add(cattle);
                await _context.SaveChangesAsync();

                // 2. Handle photo upload
                if (photo != null && photo.Length > 0)
                {
                    // Generate unique filename
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(photo.FileName)}";
                    var filePath = Path.Combine(_env.WebRootPath, "images", "cattle", fileName);

                    // Save file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }

                    // Save photo record in database
                    var cattlePhoto = new CattlePhoto
                    {
                        CattleId = cattle.CattleId,
                        PhotoUrl = $"/images/cattle/{fileName}"
                    };
                    _context.CattlePhotos.Add(cattlePhoto);
                    await _context.SaveChangesAsync();
                }

                TempData["SuccessMessage"] = "Cattle created successfully!";
                return RedirectToAction(nameof(Index));
            }

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
                .Include(c => c.CattlePhotos)   // <-- Add this line
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
            var cattle = _context.Cattle
                .Include(c => c.CattlePhotos)   // Include photos!
                .FirstOrDefault(c => c.CattleId == id);

            if (cattle == null)
                return NotFound();

            return View(cattle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cattle cattle, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                // 1. Update cattle info
                _context.Cattle.Update(cattle);
                await _context.SaveChangesAsync();

                // 2. Handle new photo
                if (photo != null && photo.Length > 0)
                {
                    // Delete old photo if exists
                    var oldPhoto = _context.CattlePhotos.FirstOrDefault(p => p.CattleId == cattle.CattleId);
                    if (oldPhoto != null)
                    {
                        var oldFilePath = Path.Combine(_env.WebRootPath, oldPhoto.PhotoUrl.TrimStart('/').Replace("/", "\\"));
                        if (System.IO.File.Exists(oldFilePath))
                            System.IO.File.Delete(oldFilePath);

                        _context.CattlePhotos.Remove(oldPhoto);
                    }

                    // Save new photo
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(photo.FileName)}";
                    var filePath = Path.Combine(_env.WebRootPath, "images", "cattle", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }

                    var newPhoto = new CattlePhoto
                    {
                        CattleId = cattle.CattleId,
                        PhotoUrl = $"/images/cattle/{fileName}"
                    };
                    _context.CattlePhotos.Add(newPhoto);
                    await _context.SaveChangesAsync();
                }

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
