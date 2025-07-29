using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Moo_Arvelous_Coders.Views.Home
{
    public class Index1Model : PageModel
    {
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Index"); // This goes to Index.cshtml
            }

            return Page();
        }
    }
}
