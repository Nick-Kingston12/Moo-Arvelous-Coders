using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Models;

namespace Moo_Arvelous_Coders.Controllers
{
    public class HerdCommentsController : Controller
    {
        // Link to HerdsController's static list
        private static List<Herd> _herds = HerdsController.HerdList;
        public static List<HerdComment> _comments = new List<HerdComment>();

        // GET: /HerdComments/Create
        public IActionResult Create()
        {
            ViewBag.Herds = _herds;
            return View(new HerdComment());
        }

        // POST: /HerdComments/Create
        [HttpPost]
        public IActionResult Create(HerdComment model)
        {
            ViewBag.Herds = _herds;

            if (ModelState.IsValid)
            {
                _comments.Add(model);
                TempData["SuccessMessage"] = "Comment recorded!";
                return RedirectToAction("Index", "Herds");
            }

            return View(model);
        }
    }
}

