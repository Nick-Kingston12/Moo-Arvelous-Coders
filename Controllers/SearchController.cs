using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Models;

namespace Moo_Arvelous_Coders.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public IActionResult Index(SearchViewModel model)
        {
            string id = model.SearchId?.Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                model.Message = "Please enter an ID.";
                return View(model);
            }

            // Check Farms
            var farm = FarmsController.FarmList.FirstOrDefault(f => f.FarmId == id);
            if (farm != null)
            {
                return RedirectToAction("Details", "Farms", new { id = id });
            }

            // Check Herds
            var herd = HerdsController.HerdList.FirstOrDefault(h => h.HerdId == id);
            if (herd != null)
            {
                return RedirectToAction("Details", "Herds", new { id = id });
            }
                     

            model.Message = "No match found for the provided ID.";
            return View(model);
        }
    }
}

