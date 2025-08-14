using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Models; // adjust to your namespace

namespace Moo_Arvelous_Coders.Controllers
{
    public class BuyerController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // This will look for Views/Buyer/Create.cshtml
        }

        [HttpPost]
        public IActionResult Create(Buyer model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add code to save Buyer to the database
                // dbContext.Buyers.Add(model);
                // dbContext.SaveChanges();

                return RedirectToAction("Index", "Home"); // Or wherever you want to go
            }
            return View(model);
        }
    }
}

