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
    public class FarmersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public FarmersController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Farmer")]
        public IActionResult Dashboard()
        {
            // You can pass data to the view if needed, e.g., farmer info
            return View();
        }

        // GET: Farmers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Farmers.ToListAsync());
        }

        // GET: Farmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Idnumber,PhoneNumber,EmailAddress,Location,Password,ConfirmPassword")] Farmer farmer)
        {
            if (!ModelState.IsValid)
                return View(farmer);

            var user = new IdentityUser
            {
                UserName = farmer.EmailAddress,
                Email = farmer.EmailAddress
            };

            var result = await _userManager.CreateAsync(user, farmer.Password);

            if (result.Succeeded)
            {
                // Ensure Farmer role exists
                if (!await _roleManager.RoleExistsAsync("Farmer"))
                    await _roleManager.CreateAsync(new IdentityRole("Farmer"));

                // Assign Farmer role
                await _userManager.AddToRoleAsync(user, "Farmer");

                // Link IdentityUser to Farmer profile
                farmer.IdentityUserId = user.Id;
                _context.Add(farmer);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Registration successful! You can now log in.";
                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(farmer);
        }

        // GET: Farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var farmer = await _context.Farmers.FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null) return NotFound();

            return View(farmer);
        }

        // GET: Farmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null) return NotFound();

            return View(farmer);
        }

        // POST: Farmers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Farmer model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var farmer = await _context.Farmers.FindAsync(model.FarmerId);
                if (farmer == null) return NotFound();

                farmer.FirstName = model.FirstName;
                farmer.LastName = model.LastName;
                farmer.EmailAddress = model.EmailAddress;
                farmer.PhoneNumber = model.PhoneNumber;
                farmer.Idnumber = model.Idnumber;
                farmer.Location = model.Location;

                _context.Update(farmer);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Farmer updated successfully!";
                return RedirectToAction(nameof(Details), new { id = farmer.FarmerId });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Farmers.Any(e => e.FarmerId == model.FarmerId)) return NotFound();
                else throw;
            }
        }

        // GET: Farmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.FarmerId == id);
            if (farmer == null) return NotFound();

            return View(farmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null) return NotFound();

            if (!string.IsNullOrEmpty(farmer.IdentityUserId))
            {
                var user = await _userManager.FindByIdAsync(farmer.IdentityUserId);
                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }
            }

            _context.Farmers.Remove(farmer);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Farmer deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
