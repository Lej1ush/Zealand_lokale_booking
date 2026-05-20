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
        private readonly IUserService _userService;

        public LogInModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public async Task OnGetAsync()
        {
            await HttpContext.SignOutAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userService.LoginAsync(Email, Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid attempt");
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToPage("/AdminDashBoard");
        }
    }
}