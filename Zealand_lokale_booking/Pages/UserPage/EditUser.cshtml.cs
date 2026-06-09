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
using Microsoft.AspNetCore.Http;

namespace Zealand_lokale_booking.Pages.UserPage
{
  

    public class EditUserModel : PageModel
    {

        private readonly IUserService _userService;

        public EditUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public IFormFile? ImageFile { get; set; }
        [BindProperty]
        public string? NewPassword { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var users = await _userService.GetUsersWithRolesAsync();

            User = users.FirstOrDefault(u => u.UserId == id);

            if (User == null)
            {
                return RedirectToPage("/UserPage/GetAllUsers");
            }

            User.Password = "";

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("User.Password");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var users = await _userService.GetUsersWithRolesAsync();

            var existingUser = users.FirstOrDefault(u => u.UserId == User.UserId);

            if (existingUser == null)
            {
                return RedirectToPage("/UserPage/GetAllUsers");
            }
            if (User.RoleId == 2 &&
    !User.Email.ToLower().EndsWith("@edu.zealand.dk"))
            {
                ModelState.AddModelError("User.Email", "Studerende skal have en email der slutter med @edu.zealand.dk");
                return Page();
            }

            if (User.RoleId == 3 &&
                !User.Email.ToLower().EndsWith("@zealand.dk"))
            {
                ModelState.AddModelError("User.Email", "Undervisere skal have en email der slutter med @zealand.dk");
                return Page();
            }
            if (!string.IsNullOrWhiteSpace(User.Name))
            {
                User.Name = char.ToUpper(User.Name[0]) +
                            User.Name.Substring(1).ToLower();
            }
            existingUser.Name = User.Name;
            existingUser.Email = User.Email;
            existingUser.RoleId = User.RoleId;


            if (!string.IsNullOrWhiteSpace(NewPassword))
            {
                existingUser.Password = NewPassword;
            }

            if (ImageFile != null)
            {
                string fileName = Guid.NewGuid().ToString()
                                  + Path.GetExtension(ImageFile.FileName);

                string folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images/users");

                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                existingUser.ImagePath = "/images/users/" + fileName;
            }
            await _userService.UpdateUserAsync(existingUser);

            return RedirectToPage("/UserPage/GetAllUsers");
        }
    }
}