using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Models; // Update this to your actual namespace
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Controllers
{
    public class HerdsController : Controller
    {
        // TEMPORARY in-memory list (until connected to DB)
        private static List<Herd> _herds = new List<Herd>();

        // GET: /Herds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Herds/Create
        [HttpPost]
        public IActionResult Create(Herd model)
        {
            if (ModelState.IsValid)
            {
                _herds.Add(model);
                return RedirectToAction("Create"); // Or redirect to a Herd list page
            }

            return View(model);
        }
    }
}

