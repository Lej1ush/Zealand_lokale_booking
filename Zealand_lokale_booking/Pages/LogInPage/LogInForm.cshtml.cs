
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
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
//    private readonly IUserService _userService;

//    public LogInFormModel(IUserService userService)
//    {
//        _userService = userService;
//    }

//    [BindProperty] public string Email { get; set; }

//    [BindProperty] public string Password { get; set; }

//    public string Message { get; set; }
//    [BindProperty(SupportsGet = true)] public RoleType? Role { get; set; }

//    public async Task<IActionResult> OnPost()
//    {
//        var user = await _userService.LoginAsync(Email, Password);

//        if (user == null)
//        {
//            Message = "Invalid login";
//            return Page();
//        }

//        if (Role.HasValue)
//        {
//            if (Role == RoleType.Admin && user.RoleId != 1)
//            {
//                Message = "Forkert rolle";
//                return Page();
//            }

//            if (Role == RoleType.Teacher && user.RoleId != 2)
//            {
//                Message = "Forkert rolle";
//                return Page();
//            }

//            if (Role == RoleType.Student && user.RoleId != 3)
//            {
//                Message = "Forkert rolle";
//                return Page();
//            }
//        }

//        string roleName = user.RoleId switch
//        {
//            1 => "Admin",
//            2 => "Teacher",
//            3 => "Student",
//            _ => "Student"
//        };

//        var claims = new List<Claim>
//        {
//            new Claim(ClaimTypes.Name, user.Email),
//            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
//            new Claim(ClaimTypes.Role, roleName)
//        };

//        var claimsIdentity = new ClaimsIdentity(
//            claims,
//            CookieAuthenticationDefaults.AuthenticationScheme
//        );

//        await HttpContext.SignInAsync(
//            CookieAuthenticationDefaults.AuthenticationScheme,
//            new ClaimsPrincipal(claimsIdentity)
//        );

//        return RedirectToPage("/UserPage/GetAllUsers");
//    }

//}


//mock+Json




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
        private readonly IUserService _userService;

        public LogInFormModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public int? Role { get; set; }

        public string Message { get; set; } = "";
        /// <summary>
        /// Logger brugeren ind ved at kontrollere email, adgangskode og rolle.
        /// Opretter derefter cookie authentication og redirecter til dashboard.
        /// </summary>
        /// <returns>
        /// Redirect til AdminDashboard eller UserDashboard.
        /// Hvis login fejler, returneres den samme side med en fejlmeddelelse.
        /// </returns>
        public async Task<IActionResult> OnPostAsync()
        {
            List<User> users = await _userService.GetUsersWithRolesAsync();

            foreach (User user in users)
            {
                if (Email.Trim().ToLower() == user.Email.Trim().ToLower())        //email
                {
                    var passwordHasher = new PasswordHasher<User>();             //tjek pin

                    var result = passwordHasher.VerifyHashedPassword(
                        user,
                        user.Password,
                        Password
                    );

                    if (result == PasswordVerificationResult.Success)
                    {
                        if (user.RoleId != Role)                                   //authorization
                        {
                            Message = "Du har ikke adgang til denne login.";
                            return Page();
                        }

                        string roleName = user.Role?.RoleName ?? "User";

                        var claims = new List<Claim>             //Claims indeholder oplysninger om den loggede bruger
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                            new Claim(ClaimTypes.Name, user.Name),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.Role, roleName)
                        };

                        var claimsIdentity = new ClaimsIdentity(                    
                            claims,
                            CookieAuthenticationDefaults.AuthenticationScheme
                        );
                        


                        await HttpContext.SignInAsync(     
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity)
                        );

                        if (roleName == "Admin")
                        {
                            return RedirectToPage("/LogInPage/AdminDashBoard");
                        }


                        return RedirectToPage("/UserPage/UserDashBoard");
                        //return RedirectToPage("/LogInPage/AdminDashBoard");         /* AccessDenied*/
                    }
                }
            }

            Message = "Forkert email eller adgangskode.";
            return Page();
        }
    }
}