using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Zealand_lokale_booking.Services.UserServ;

namespace Zealand_lokale_booking.Pages.LogInPage
{
    public class LogInModel : PageModel
    {
        public async Task OnGetAsync()
        {
            await HttpContext.SignOutAsync();
        }
    }
}
