using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Data;
using Moo_Arvelous_Coders.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Moo_Arvelous_Coders.Controllers
{
    public class BuyerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public BuyerController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Buyer")]
        public IActionResult Dashboard()
        {
            // You can pass data to the view if needed, e.g., buyer info
            return View();
        }
        // GET: Buyers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Buyers.ToListAsync());
        }

        // GET: Buyers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buyers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BfirstName,BlastName,BphoneNumber,Bemail,Bidnumber,OrganizationName,BPassword,BConfirmPassword")] Buyer buyer)
        {
            if (!ModelState.IsValid) return View(buyer);

            var user = new IdentityUser
            {
                UserName = buyer.Bemail,
                Email = buyer.Bemail
            };

            var result = await _userManager.CreateAsync(user, buyer.BPassword);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("Buyer"))
                    await _roleManager.CreateAsync(new IdentityRole("Buyer"));

                await _userManager.AddToRoleAsync(user, "Buyer");

                buyer.IdentityUserId = user.Id;
                _context.Add(buyer);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Buyer registration successful! You can now log in.";
                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(buyer);
        }

        // GET: Buyers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var buyer = await _context.Buyers.FirstOrDefaultAsync(b => b.BuyerId == id);
            if (buyer == null) return NotFound();

            return View(buyer);
        }

        // GET: Buyers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var buyer = await _context.Buyers.FindAsync(id);
            if (buyer == null) return NotFound();

            return View(buyer);
        }

        // POST: Buyers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Buyer model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var buyer = await _context.Buyers.FindAsync(model.BuyerId);
                if (buyer == null) return NotFound();

                buyer.BfirstName = model.BfirstName;
                buyer.BlastName = model.BlastName;
                buyer.BphoneNumber = model.BphoneNumber;
                buyer.Bemail = model.Bemail;
                buyer.Bidnumber = model.Bidnumber;
                buyer.OrganizationName = model.OrganizationName;

                _context.Update(buyer);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Buyer updated successfully!";
                return RedirectToAction(nameof(Details), new { id = buyer.BuyerId });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Buyers.Any(e => e.BuyerId == model.BuyerId)) return NotFound();
                else throw;
            }
        }

        // GET: Buyers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var buyer = await _context.Buyers.FirstOrDefaultAsync(b => b.BuyerId == id);
            if (buyer == null) return NotFound();

            return View(buyer);
        }

        // POST: Buyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buyer = await _context.Buyers.FindAsync(id);
            if (buyer == null) return NotFound();

            if (!string.IsNullOrEmpty(buyer.IdentityUserId))
            {
                var user = await _userManager.FindByIdAsync(buyer.IdentityUserId);
                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }
            }

            _context.Buyers.Remove(buyer);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Buyer deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
