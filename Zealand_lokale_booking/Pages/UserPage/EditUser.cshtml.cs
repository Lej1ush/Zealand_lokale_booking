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
            var users = await _userService.GetUsersWithRolesAsync();

            var existingUser = users.FirstOrDefault(u => u.UserId == User.UserId);

            if (existingUser == null)
            {
                return RedirectToPage("/UserPage/GetAllUsers");
            }

            existingUser.Name = User.Name;
            existingUser.Email = User.Email;
            existingUser.Password = User.Password;
            existingUser.RoleId = User.RoleId;
            existingUser.ImagePath = User.ImagePath;

            if (ImageFile != null)
            {
                string fileName = Guid.NewGuid().ToString()
                                  + Path.GetExtension(ImageFile.FileName);

                string folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/Photo");

                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                existingUser.ImagePath = "/Photo/" + fileName;
            }
            await _userService.UpdateUserAsync(existingUser);

            return RedirectToPage("/UserPage/GetAllUsers");
        }
    }
}