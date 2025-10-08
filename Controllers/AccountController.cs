using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Models;
using System.Threading.Tasks;

namespace Moo_Arvelous_Coders.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // ===== Login =====
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.EmailAddress);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    // Check user roles
                    if (await _userManager.IsInRoleAsync(user, "Farmer"))
                    {
                        return RedirectToAction("Dashboard", "Farmers");
                    }
                    else if (await _userManager.IsInRoleAsync(user, "Buyer"))
                    {
                        return RedirectToAction("Dashboard", "Buyer");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }


        // ===== Logout =====
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
