using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Zealand_lokale_booking.Pages.LogInPage
{
    public class LogOutModel : PageModel
    {
        public async Task<IActionResult> OnPost()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
