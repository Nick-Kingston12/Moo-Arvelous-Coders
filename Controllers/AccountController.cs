using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Moo_Arvelous_Coders.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RegisterFarmer()
        {
            return View();
        }

        public IActionResult RegisterBuyer()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string EmailAddress, string Password)
        {
            var result = await _signInManager.PasswordSignInAsync(EmailAddress, Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Logout"); // TEMP redirect to test logout
            }

            ViewBag.Message = "Invalid login";
            return View();
        }

        // GET: /Account/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View(); // Show your styled logout page
        }
    }
}
