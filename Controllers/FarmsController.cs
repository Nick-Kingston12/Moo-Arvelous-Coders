using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Models; // Update this to your actual namespace
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Controllers
{
    public class FarmsController : Controller
    {
        // TEMPORARY in-memory list (until DB is set up)
        private static List<Farm> _farms = new List<Farm>();

        // GET: /Farms/
        public IActionResult Index()
        {
            return View(_farms);
        }

        // GET: /Farms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Farms/Create
        [HttpPost]
        public IActionResult Create(Farm model)
        {
            if (ModelState.IsValid)
            {
                _farms.Add(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}