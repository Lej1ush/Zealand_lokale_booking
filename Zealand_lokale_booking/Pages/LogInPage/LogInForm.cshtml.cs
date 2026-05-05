//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.ComponentModel.DataAnnotations;
//using System.Security.Claims;
//using Zealand_lokale_booking.Models;
//using Zealand_lokale_booking.Services.UserServ;

//namespace Zealand_lokale_booking.Pages.LogInPage
//{
//    public class LogInFormModel : PageModel
//    {
//        private readonly IUserService _userService;

//        public LogInFormModel(IUserService userService)
//        {
//            _userService = userService;
//        }
//        [BindProperty]
//        public string Email { get; set; }

//        [BindProperty]
//        public string Password { get; set; }

//        public string Message { get; set; }

//        public IActionResult OnPost()
//        {
//            var user = _userService.Login(Email, Password);

//            if (user == null)
//            {
//                Message = "Invalid login"; 
//                return Page();
//            }


//            return RedirectToPage("/UserPage/GetAllUsers");
//        }
//    }
//}                                                                                    //mock+Json




//////////////////////DB/////////////////////////


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.UserServ;

namespace Zealand_lokale_booking.Pages.LogInPage
{
    public class LogInFormModel : PageModel
    {
        private readonly IDbUserService _userService;

        public LogInFormModel(IDbUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public string Email { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public RoleType Role { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            List<User> users = await _userService.GetAllUsersAsync();
            var passwordHasher = new PasswordHasher<string>();

            foreach (User user in users)
            {
                if (Email == user.Email)
                {
                    var result = passwordHasher.VerifyHashedPassword(
                        null,
                        user.Password,
                        Password
                    );

                    if (result == PasswordVerificationResult.Success)
                    {
                        if (user.Role != Role)
                        {
                            Message = "Forkert login type!";
                            return Page();
                        }

                        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

                        var claimsIdentity = new ClaimsIdentity(
                            claims,
                            CookieAuthenticationDefaults.AuthenticationScheme
                        );

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity)
                        );

                        if (user.Role == RoleType.Admin)
                        {
                            return RedirectToPage("/LogInPage/AdminDashBoard");
                        }
                        else
                        {
                            return RedirectToPage("/UserPage/GetAllUsers");
                        }
                    }
                }
            }

            Message = "Invalid attempt";
            return Page();
        }
    }

}
