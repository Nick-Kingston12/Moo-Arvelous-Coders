using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Data;
using Moo_Arvelous_Coders.Models;
using System.Threading.Tasks;

namespace Moo_Arvelous_Coders.Controllers
{
    public class HerdCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HerdCommentsController(ApplicationDbContext context)
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
                // No need to generate CommentId manually, database handles int identity
                _context.HerdComments.Add(model);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Comment recorded!";

                // Redirect to herd's details page
                return RedirectToAction("Details", "Herds", new { id = model.HerdId });
            }

            // If model is invalid, stay on the page and show errors
            return View(model);
        }
        // POST: HerdComments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _context.HerdComments.FindAsync(id);
            if (comment == null) return NotFound();

            int herdId = comment.HerdId;

            _context.HerdComments.Remove(comment);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Comment deleted successfully!";
            return RedirectToAction("Details", "Herds", new { id = herdId });
        }

    }
}

