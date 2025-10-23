using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Json(new { results = new List<object>() });

            query = query.Trim();
            var results = new List<object>();

            // 1. Farmers
            var farmers = await _context.Farmers
                .Where(f => f.FirstName.Contains(query) || f.LastName.Contains(query))
                .Select(f => new
                {
                    Type = "Farmer",
                    Title = $"{f.FirstName} {f.LastName}",
                    Url = Url.Action("Details", "Farmers", new { id = f.FarmerId })
                })
                .ToListAsync();
            results.AddRange(farmers);

            // 2. Farms
            var farms = await _context.Farms
                .Where(f => f.FarmName.Contains(query))
                .Select(f => new
                {
                    Type = "Farm",
                    Title = f.FarmName,
                    Url = Url.Action("Details", "Farms", new { id = f.FarmId })
                })
                .ToListAsync();
            results.AddRange(farms);

            // 3. Herds
            var herds = await _context.Herds
                .Where(h => h.HerdName.Contains(query))
                .Select(h => new
                {
                    Type = "Herd",
                    Title = h.HerdName,
                    Url = Url.Action("Details", "Herds", new { id = h.HerdId })
                })
                .ToListAsync();
            results.AddRange(herds);

            // 4. Cattle (search by numeric ID or status)
            if (int.TryParse(query, out int cattleId))
            {
                var cattleById = await _context.Cattle
                    .Where(c => c.CattleId == cattleId)
                    .Select(c => new
                    {
                        Type = "Cattle",
                        Title = $"{c.Breed} (ID: {c.CattleId})",
                        Url = Url.Action("Details", "Cattle", new { id = c.CattleId })
                    })
                    .ToListAsync();
                results.AddRange(cattleById);
            }

            var cattleByStatus = await _context.Cattle
                .Where(c => c.Status.Contains(query) || c.Breed.Contains(query))
                .Select(c => new
                {
                    Type = "Cattle",
                    Title = $"{c.Breed} ({c.Status})",
                    Url = Url.Action("Details", "Cattle", new { id = c.CattleId })
                })
                .ToListAsync();
            results.AddRange(cattleByStatus);

            // 5. Health Records (treatment type)
            var healthRecords = await _context.CattleHealthRecords
                .Where(c => c.TreatmentType.Contains(query))
                .Select(c => new
                {
                    Type = "Health Record",
                    Title = $"{c.TreatmentType} (Cattle #{c.CattleId})",
                    Url = Url.Action("Index", "HealthRecords", new { cattleId = c.CattleId })
                })
                .ToListAsync();
            results.AddRange(healthRecords);

            return Json(new { results });
        }
        [HttpGet]
        public async Task<IActionResult> BuyerSearch(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Json(new { results = new List<object>() });

            query = query.Trim();
            var results = new List<object>();

            // 1. Farmers by name
            var farmers = await _context.Farmers
                .Where(f => f.FirstName.Contains(query) || f.LastName.Contains(query))
                .Select(f => new
                {
                    type = "Farmer",
                    title = $"{f.FirstName} {f.LastName}",
                    url = Url.Action("Details", "Farmers", new { id = f.FarmerId })
                })
                .ToListAsync();
            results.AddRange(farmers);

            // 2. Cattle by status
            var cattleMatches = await _context.Cattle
                .Where(c => c.Status.Contains(query))
                .Select(c => new
                {
                    type = "Cattle",
                    title = $"{c.Breed} (Status: {c.Status})",
                    url = Url.Action("Details", "Cattle", new { id = c.CattleId })
                })
                .ToListAsync();
            results.AddRange(cattleMatches);

            return Json(new { results });
        }

    }
}

