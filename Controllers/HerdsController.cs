using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Models;

namespace Moo_Arvelous_Coders.Controllers
{
    public class HerdsController : Controller
    {
        private static List<Herd> _herds = new List<Herd>();

        public IActionResult Index()
        {
            return View(_herds);
        }
        // GET: /Herds/Create
        public IActionResult Create()
        {
            var model = new Herd
            {
                HerdId = Guid.NewGuid().ToString().Substring(0, 8)
            };
            return View(model);
        }

        // POST: /Herds/Create
        [HttpPost]
        public IActionResult Create(Herd model)
        {
            if (ModelState.IsValid)
            {
                // Only regenerate if ID wasn't passed in
                if (string.IsNullOrWhiteSpace(model.HerdId))
                {
                    model.HerdId = Guid.NewGuid().ToString().Substring(0, 8);
                }

                _herds.Add(model);
                TempData["SuccessMessage"] = "Herd created successfully!";
                return RedirectToAction("Index", "Herds");
                // Send to homepage
            }

            // Validation failed
            return View(model);
        }
        public IActionResult Details(string id)
        {
            var herd = _herds.FirstOrDefault(h => h.HerdId == id);
            if (herd == null)
            {
                return NotFound();
            }

            return View(herd);
        }

        // GET: /Herds/Edit/{id}
        public IActionResult Edit(string id)
        {
            var herd = _herds.FirstOrDefault(h => h.HerdId == id);
            if (herd == null)
            {
                return NotFound();
            }

            return View(herd);
        }

        // POST: /Herds/Edit
        [HttpPost]
        public IActionResult Edit(Herd model)
        {
            if (ModelState.IsValid)
            {
                var herd = _herds.FirstOrDefault(h => h.HerdId == model.HerdId);
                if (herd == null)
                {
                    return NotFound();
                }

                herd.HerdName = model.HerdName;
                herd.Herdsize = model.Herdsize;

                TempData["SuccessMessage"] = "Herd details updated successfully!";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /Herds/Delete/{id}
        public IActionResult Delete(string id)
        {
            var herd = _herds.FirstOrDefault(h => h.HerdId == id);
            if (herd == null)
            {
                return NotFound();
            }

            return View(herd);
        }

        // POST: /Herds/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var herd = _herds.FirstOrDefault(h => h.HerdId == id);
            if (herd == null)
            {
                return NotFound();
            }

            _herds.Remove(herd);
            TempData["SuccessMessage"] = "Herd deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}

