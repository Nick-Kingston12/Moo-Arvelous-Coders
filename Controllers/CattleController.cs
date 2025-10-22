using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Data;
using Moo_Arvelous_Coders.Models;
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

            // ✅ Default DateOfBirth = today
            var newCattle = new Cattle
            {
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today)
            };

            return View(newCattle);
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
                .Include(c => c.Herd)
                .Include(c => c.CattlePhotos)   // <-- Add this line
                .FirstOrDefault(c => c.CattleId == id);

            if (cattle == null)
                return NotFound();

            return View(cattle);
        }


        // ======================
        // EDIT CATTLE
        // ======================
        [Authorize(Roles = "Farmer")]

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cattle = _context.Cattle
                .Include(c => c.CattlePhotos)
                .FirstOrDefault(c => c.CattleId == id);

            if (cattle == null)
                return NotFound();

            ViewBag.HerdList = new SelectList(_context.Herds, "HerdId", "HerdName", cattle.HerdId);
            return View(cattle);
        }

        [Authorize(Roles = "Farmer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cattle model, IFormFile photo)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate dropdown
                ViewBag.HerdList = new SelectList(_context.Herds, "HerdId", "HerdName", model.HerdId);
                return View(model);
            }

            var cattle = await _context.Cattle
                .Include(c => c.CattlePhotos)
                .FirstOrDefaultAsync(c => c.CattleId == model.CattleId);

            if (cattle == null)
                return NotFound();

            // Update fields
            cattle.Gender = model.Gender;
            cattle.Breed = model.Breed;
            cattle.DateOfBirth = model.DateOfBirth;
            cattle.Weight = model.Weight;
            cattle.HerdId = model.HerdId;
            cattle.Status = model.Status;
            cattle.DateOfDeath = model.DateOfDeath;

            // Handle photo upload if provided
            if (photo != null && photo.Length > 0)
            {
                // Remove old photo
                var oldPhoto = cattle.CattlePhotos.FirstOrDefault();
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

                cattle.CattlePhotos.Add(new CattlePhoto { PhotoUrl = $"/images/cattle/{fileName}" });
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Cattle updated successfully!";
            return RedirectToAction(nameof(Details), new { id = cattle.CattleId });
        }



        // ======================
        // DELETE CATTLE
        // ======================
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cattle = _context.Cattle
                .Include(c => c.CattlePhotos)
                .Include(c => c.CattleHealthRecords)
                .FirstOrDefault(c => c.CattleId == id);

            if (cattle == null)
                return NotFound();

            return View(cattle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cattle = _context.Cattle
                .Include(c => c.CattlePhotos)
                .Include(c => c.CattleHealthRecords)
                .FirstOrDefault(c => c.CattleId == id);

            if (cattle != null)
            {
                // Remove related health records
                if (cattle.CattleHealthRecords.Any())
                    _context.CattleHealthRecords.RemoveRange(cattle.CattleHealthRecords);

                // Remove related photos (and delete files if needed)
                if (cattle.CattlePhotos.Any())
                {
                    foreach (var photo in cattle.CattlePhotos)
                    {
                        var filePath = Path.Combine(_env.WebRootPath, photo.PhotoUrl.TrimStart('/').Replace("/", "\\"));
                        if (System.IO.File.Exists(filePath))
                            System.IO.File.Delete(filePath);
                    }

                    _context.CattlePhotos.RemoveRange(cattle.CattlePhotos);
                }

                // Delete the cattle itself
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
        // ======================
        // VIEW CATTLE FOR SALE
        // ======================
        public async Task<IActionResult> ForSale()
        {
            var forSaleCattle = await _context.Cattle
                .Include(c => c.Herd)
                .Include(c => c.Farmer)
                .Where(c => c.Status == "Sell" || c.Status == "Prepping for Sale")
                .ToListAsync();

            return View(forSaleCattle);
        }

    }
}
