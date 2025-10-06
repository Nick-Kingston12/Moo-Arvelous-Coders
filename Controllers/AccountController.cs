using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moo_Arvelous_Coders.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Moo_Arvelous_Coders.ViewModels;

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
                return View(model); // preserves input

            var result = await _signInManager.PasswordSignInAsync(
                model.EmailAddress, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home"); // redirect after successful login

            ModelState.AddModelError("", "Invalid login attempt");
            return View(model); // preserves input on failure
        }





        // ===== Logout =====
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View(); // Show a logout confirmation page
        }

        // ===== Register Farmer =====
        [HttpGet]
        public IActionResult RegisterFarmer()
        {
            return View(new RegisterFarmerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterFarmer(RegisterFarmerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new IdentityUser { UserName = model.EmailAddress, Email = model.EmailAddress };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Optionally, add claims/roles here for Farmer role
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        // ===== Register Buyer =====
        [HttpGet]
        public IActionResult RegisterBuyer()
        {
            return View(new RegisterBuyerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterBuyer(RegisterBuyerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new IdentityUser { UserName = model.EmailAddress, Email = model.EmailAddress };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Optionally, add claims/roles here for Buyer role
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
    }

    // ===== ViewModels =====

  

    public class RegisterFarmerViewModel
    {
        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

       

        
    }

    public class RegisterBuyerViewModel
    {
        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        // Add any buyer-specific registration fields here
    }
}
