using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Data;
using Moo_Arvelous_Coders.Models;
using System.Threading.Tasks;

namespace Moo_Arvelous_Coders.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dashboard search form submits here via GET
        [HttpGet]
        public async Task<IActionResult> Index(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                TempData["ErrorMessage"] = "Please enter a search term.";
                return RedirectToAction("Index", "Dashboard");
            }

            query = query.Trim();

            // 1. Search Farmer by first or last name
            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(f => f.FirstName.Contains(query) || f.LastName.Contains(query));
            if (farmer != null)
                return RedirectToAction("Details", "Farmers", new { id = farmer.FarmerId });

            // 2. Search Farm by name
            var farm = await _context.Farms
                .FirstOrDefaultAsync(f => f.FarmName.Contains(query));
            if (farm != null)
                return RedirectToAction("Details", "Farms", new { id = farm.FarmId });

            // 3. Search Herd by name
            var herd = await _context.Herds
                .FirstOrDefaultAsync(h => h.HerdName.Contains(query));
            if (herd != null)
                return RedirectToAction("Details", "Herds", new { id = herd.HerdId });

            // 4. Search Cattle by ID
            if (int.TryParse(query, out int cattleId))
            {
                var cattle = await _context.Cattle
                    .FirstOrDefaultAsync(c => c.CattleId == cattleId);
                if (cattle != null)
                    return RedirectToAction("Details", "Cattle", new { id = cattle.CattleId });
            }

            // 5. Search Cattle by status
            var cattleStatus = await _context.Cattle
                .FirstOrDefaultAsync(c => c.Status.Contains(query));
            if (cattleStatus != null)
                return RedirectToAction("Details", "Cattle", new { id = cattleStatus.CattleId });


            var treatmentRecord = await _context.CattleHealthRecords
    .FirstOrDefaultAsync(c => c.TreatmentType.Contains(query));

            if (treatmentRecord != null)
                return RedirectToAction("Index", "HealthRecords", new { cattleId = treatmentRecord.CattleId });


            // Nothing found
            TempData["ErrorMessage"] = $"No results found for \"{query}\".";
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
