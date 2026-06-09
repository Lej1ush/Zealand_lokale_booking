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
using Microsoft.AspNetCore.Http;

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
        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public void OnGet()
        {
            User = new User();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
                return Page();
            if (!string.IsNullOrWhiteSpace(User.Name))
            {
                User.Name = char.ToUpper(User.Name[0]) + User.Name.Substring(1).ToLower();
            }
            if (string.IsNullOrWhiteSpace(User.Password))
            {
                ModelState.AddModelError("User.Password",
                    "Der skal angives en adgangskode.");
                return Page();
            }
            // Student
            if (User.RoleId == 2 &&
                !User.Email.ToLower().EndsWith("@edu.zealand.dk"))
            {
                ModelState.AddModelError("User.Email",
      "Studerende skal have en email der slutter med @edu.zealand.dk");
                return Page();
            }

// Teacher
            if (User.RoleId == 3 &&
                !User.Email.ToLower().EndsWith("@zealand.dk"))
            {
                ModelState.AddModelError("User.Email", "Undervisere skal have en email der slutter med @zealand.dk");
                return Page();
            }
            if (ImageFile != null)
            {
                string fileName = Guid.NewGuid().ToString()
                                  + Path.GetExtension(ImageFile.FileName);

                string folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images/users");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                User.ImagePath = "/images/users/" + fileName;
            }
            await _userService.CreateUserAsync(User);

            return RedirectToPage("/UserPage/GetAllUsers");
        }
    }
}
