using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Models;
using System.Threading.Tasks;

namespace Moo_Arvelous_Coders.Controllers
{
    public class SearchController : Controller
    {
        private readonly MooArvelousDbContext _context;

        public SearchController(MooArvelousDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchViewModel model)
        {
            string id = model.SearchId?.Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                model.Message = "Please enter an ID.";
                return View(model);
            }

            // Check Farms in DB
            var farm = await _context.Farms.FirstOrDefaultAsync(f => f.FarmId == id);
            if (farm != null)
            {
                return RedirectToAction("Details", "Farms", new { id });
            }

            // Check Herds in DB
            var herd = await _context.Herds.FirstOrDefaultAsync(h => h.HerdId == id);
            if (herd != null)
            {
                return RedirectToAction("Details", "Herds", new { id });
            }

            model.Message = "No match found for the provided ID.";
            return View(model);
        }
    }
}


