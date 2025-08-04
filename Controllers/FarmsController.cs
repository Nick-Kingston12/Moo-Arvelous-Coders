using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moo_Arvelous_Coders.Controllers
{
    public class FarmsController : Controller
    {
        // TEMPORARY in-memory list (until DB is set up)
        private static List<Farm> _farms = new List<Farm>();

        // GET: /Farms/Create
        public IActionResult Create()
        {
            // 🔧 Generate ID here too so user can SEE it before submitting
            var model = new Farm
            {
                FarmId = Guid.NewGuid().ToString().Substring(0, 8)
            };

            return View(model);
        }

        // GET: /Farms/
        public IActionResult Index()
        {
            return View(_farms);
        }

        // POST: /Farms/Create
        [HttpPost]
        public IActionResult Create(Farm model)
        {
            if (ModelState.IsValid)
            {
                // ✅ Only re-generate ID if for some reason it's still empty
                if (string.IsNullOrWhiteSpace(model.FarmId))
                {
                    model.FarmId = Guid.NewGuid().ToString().Substring(0, 8);
                }

                // Check for duplicate FarmName
                var exists = _farms.Any(f => f.FarmName == model.FarmName);
                if (exists)
                {
                    ModelState.AddModelError("FarmName", "A farm with this name already exists.");
                    return View(model);
                }

                _farms.Add(model);
                TempData["SuccessMessage"] = "Farm created successfully!";
                return RedirectToAction("Index");
            }

            // 🔁 Re-show form with errors and current Farm ID
            return View(model);
        }
        // GET: /Farms/Edit/{id}
        public IActionResult Edit(string id)
        {
            var farm = _farms.FirstOrDefault(f => f.FarmId == id);
            if (farm == null)
            {
                return NotFound();
            }
            return View(farm);
        }
        // POST: /Farms/Edit/{id}
        [HttpPost]
        public IActionResult Edit(Farm model)
        {
            if (ModelState.IsValid)
            {
                var farm = _farms.FirstOrDefault(f => f.FarmId == model.FarmId);
                if (farm == null) return NotFound();

                // Update all fields
                farm.FarmName = model.FarmName;
                farm.Location = model.Location;
                farm.PriceBought = model.PriceBought;
                farm.FarmSize = model.FarmSize;
                farm.Manager = model.Manager;

                TempData["SuccessMessage"] = "Farm details updated successfully!";
                return RedirectToAction("Index");
            }

            // Return view with validation errors
            return View(model);
        }
        //GET: /Farms/Delete/{id}
        public IActionResult Delete(string id)
        {
            var farm = _farms.FirstOrDefault(f => f.FarmId == id);
            if (farm == null) return NotFound();

            return View(farm); // Go to confirmation page
        }

        // POST: /Farms/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var farm = _farms.FirstOrDefault(f => f.FarmId == id);
            if (farm == null) return NotFound();

            _farms.Remove(farm);
            TempData["SuccessMessage"] = "Farm deleted successfully!";
            return RedirectToAction("Index");
        }




    }
}
