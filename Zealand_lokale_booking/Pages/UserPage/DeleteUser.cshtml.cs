//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Zealand_lokale_booking.Models;
//using Zealand_lokale_booking.Services.UserServ;

//namespace Zealand_lokale_booking.Pages.UserPage
//{
//    public class DeleteUserModel : PageModel
//    {
//            private readonly IUserService _userService;

//            public DeleteUserModel(IUserService userService)
//            {
//                _userService = userService;
//            }

//            [BindProperty]
//            public User User { get; set; }

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
//            {
//                _userService.DeleteUser(User.UserId);

//                return RedirectToPage("/UserPage/GetAllUsers");
//            }
//        }
//    }




using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.UserServ;

namespace Zealand_lokale_booking.Pages.UserPage
{
    [Authorize(Roles = "Admin")]

    public class DeleteUserModel : PageModel
    {

        private readonly IUserService _userService;

        public DeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var users = await _userService.GetUsersWithRolesAsync();

            User = users.FirstOrDefault(u => u.UserId == id);

            if (User == null)
            {
                return RedirectToPage("/UserPage/GetAllUsers");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _userService.DeleteUserAsync(User.UserId);

            return RedirectToPage("/UserPage/GetAllUsers");
        }
    }
}