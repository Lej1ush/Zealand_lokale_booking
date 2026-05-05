//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Zealand_lokale_booking.Models;
//using Zealand_lokale_booking.Services.UserServ;

//namespace Zealand_lokale_booking.Pages.UserPage
//{
//    public class EditUserModel : PageModel
//    {
//        private readonly IUserService _userService;

//        public EditUserModel(IUserService userService)
//        {
//            _userService = userService;
//        }

//        [BindProperty]
//        public User User { get; set; }

//        public IActionResult OnGet(int id)
//        {
//            User = _userService.GetAllUsers()
//                .FirstOrDefault(u => u.UserId == id);

//            if (User == null)
//            {
//                return RedirectToPage("/UserPage/GetAllUsers");
//            }

//            return Page();
//        }

//        public IActionResult OnPost()
//        {
//            if (!ModelState.IsValid)
//                return Page();

//            _userService.UpdateUser(User);

//            return RedirectToPage("/UserPage/GetAllUsers");
//        }
//    }
//}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.UserServ;

namespace Zealand_lokale_booking.Pages.UserPage
{
    [Authorize(Roles = "Admin")]

    public class EditUserModel : PageModel
    {

        private readonly IDbUserService _userService;

        public EditUserModel(IDbUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var users = await _userService.GetAllUsersAsync();

            User = users.FirstOrDefault(u => u.UserId == id);

            if (User == null)
            {
                return RedirectToPage("/UserPage/GetAllUsers");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _userService.UpdateUserAsync(User);

            return RedirectToPage("/UserPage/GetAllUsers");
        }
    }
}