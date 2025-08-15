using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Models;
using System.Threading.Tasks;

namespace Moo_Arvelous_Coders.Controllers
{
    public class HerdCommentsController : Controller
    {
        private readonly MooArvelousDbContext _context;

        public HerdCommentsController(MooArvelousDbContext context)
        {
            _context = context;
        }

        // GET: HerdComments/Create
        public async Task<IActionResult> Create()
        {
            // Pass all herds from DB to the view for dropdown/select
            ViewBag.Herds = await _context.Herds.ToListAsync();
            return View(new HerdComment());
        }

        // POST: HerdComments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HerdComment model)
        {
            // Reload dropdown in case we need to redisplay the view
            ViewBag.Herds = await _context.Herds.ToListAsync();

            if (ModelState.IsValid)
            {
                // Generate CommentId if not already set
                if (string.IsNullOrWhiteSpace(model.CommentId))
                {
                    model.CommentId = Guid.NewGuid().ToString().Substring(0, 8);
                }

                _context.HerdComments.Add(model);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Comment recorded!";

                // ✅ Redirect straight to herd's details page
                return RedirectToAction("Details", "Herds", new { id = model.HerdId });
            }

            // If model is invalid, stay on the page and show errors
            return View(model);
        }

    }
}


