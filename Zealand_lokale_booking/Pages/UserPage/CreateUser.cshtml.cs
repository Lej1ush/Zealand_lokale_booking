//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Zealand_lokale_booking.Models;
//using Zealand_lokale_booking.Services.UserServ;

//namespace Zealand_lokale_booking.Pages.UserPage
//{
//    public class CreateUserModel : PageModel
//    {

//            private readonly IUserService _userService;

//        public CreateUserModel(IUserService userService)
//        {
//            _userService = userService;
//        }

//        [BindProperty]
//        public User User { get; set; }

//        public void OnGet()
//        {
//            User = new User();
//        }

//        public IActionResult OnPost()
//        {
//            if (!ModelState.IsValid)
//                return Page();

//            //  Student
//            if (User.Role == RoleType.Student &&
//                !User.Email.ToLower().EndsWith("@edu.zealand.dk"))
//            {
//                ModelState.AddModelError("", "Studerende skal have en email der slutter med @edu.zealand.dk");
//                return Page();
//            }

//            //  Teacher
//            if (User.Role == RoleType.Teacher &&
//                !User.Email.ToLower().EndsWith("@zealand.dk"))
//            {
//                ModelState.AddModelError("", "Undervisere skal have en email der slutter med @zealand.dk");
//                return Page();
//            }

//            _userService.CreateUser(User);

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
    public class CreateUserModel : PageModel
    {

        private readonly IUserService _userService;

        public CreateUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
            User = new User();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Student
            // Student
            if (User.RoleId == 1 &&
                !User.Email.ToLower().EndsWith("@edu.zealand.dk"))
            {
                ModelState.AddModelError("", "Studerende skal have en email der slutter med @edu.zealand.dk");
                return Page();
            }

// Teacher
            if (User.RoleId == 2 &&
                !User.Email.ToLower().EndsWith("@zealand.dk"))
            {
                ModelState.AddModelError("", "Undervisere skal have en email der slutter med @zealand.dk");
                return Page();
            }

            await _userService.CreateUserAsync(User);

            return RedirectToPage("/UserPage/GetAllUsers");
        }
    }
}