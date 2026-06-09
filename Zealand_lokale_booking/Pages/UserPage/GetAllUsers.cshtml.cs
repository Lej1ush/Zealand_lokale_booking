//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Zealand_lokale_booking.Comparators.Ascending;
//using Zealand_lokale_booking.Comparators.Descending;
//using Zealand_lokale_booking.Models;
//using Zealand_lokale_booking.Services.UserServ;

//namespace Zealand_lokale_booking.Pages.UserPage
//{
//    public class GetAllUsersModel : PageModel
//    {
//        private readonly IUserService _userService;

//        public List<User> Users { get; set; } = new();

//        public GetAllUsersModel(IUserService userService)
//        {
//            _userService = userService;
//        }

//        [BindProperty]
//        public string? SearchString { get; set; }

//        [BindProperty]
//        public int? SearchId { get; set; }

//        [BindProperty(SupportsGet = true)]
//        public int? RoleId { get; set; }

//        public void OnGet()
//        {
//            if (RoleId.HasValue)
//            {
//                Users = _userService.GetUsersByRole(RoleId.Value);
//            }
//            else
//            {
//                Users = _userService.GetAllUsers();
//            }
//        }

//        public IActionResult OnPostNameSearch()
//        {
//            Users = _userService.GetAllUsers()
//                .Where(u => !string.IsNullOrEmpty(u.Name) &&
//                            !string.IsNullOrEmpty(SearchString) &&
//                            u.Name.ToLower().Contains(SearchString.ToLower()))
//                .ToList();

//            return Page();
//        }

//        public IActionResult OnPostIdSearch()
//        {
//            if (SearchId.HasValue)
//            {
//                Users = _userService.GetAllUsers()
//                    .Where(u => u.UserId == SearchId.Value)
//                    .ToList();
//            }
//            else
//            {
//                Users = _userService.GetAllUsers();
//            }

//            return Page();
//        }

//        public IActionResult OnGetSortById()
//        {
//            Users = _userService.GetAllUsers();
//            Users.Sort(new IdAscendingComparator());
//            return Page();
//        }

//        public IActionResult OnGetSortByIdDesc()
//        {
//            Users = _userService.GetAllUsers();
//            Users.Sort(new IdDescendingComparator());
//            return Page();
//        }

//        public IActionResult OnGetSortByName()
//        {
//            Users = _userService.GetAllUsers();
//            Users.Sort(new NameAscendingComparator());
//            return Page();
//        }

//        public IActionResult OnGetSortByNameDesc()
//        {
//            Users = _userService.GetAllUsers();
//            Users.Sort(new NameDescendingComparator());
//            return Page();
//        }

//        public IActionResult OnGetRoleFilter(int roleId)
//        {
//            Users = _userService.GetUsersByRole(roleId);
//            return Page();
//        }
//    }
//}



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Comparators.Ascending;
using Zealand_lokale_booking.Comparators.Descending;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.UserServ;

namespace Zealand_lokale_booking.Pages.UserPage
{
    [Authorize(Roles = "Admin")]
    public class GetAllUsersModel : PageModel
    {
        private readonly IUserService _userService;

        public List<User> Users { get; set; } = new List<User>();

        [BindProperty]
        public string SearchString { get; set; }

        [BindProperty]
        public int? SearchId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Role { get; set; }

        public GetAllUsersModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnGet()
        {
            if (Role.HasValue)
            {
                Users = await _userService.GetUsersByRoleAsync(Role.Value);
            }
            else
            {
                Users = await _userService.GetUsersWithRolesAsync();
            }
        }

        public async Task<IActionResult> OnPostNameSearch()
        {
            var allUsers = await _userService.GetUsersWithRolesAsync();

            Users = allUsers
                .Where(u => u.Name != null &&
                            !string.IsNullOrEmpty(SearchString) &&
                            u.Name.ToLower().Contains(SearchString.ToLower()))
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostIdSearch()
        {
            var allUsers = await _userService.GetUsersWithRolesAsync();

            if (SearchId.HasValue)
            {
                Users = allUsers
                    .Where(u => u.UserId == SearchId.Value)
                    .ToList();
            }
            else
            {
                Users = allUsers;
            }

            return Page();
        }

        public async Task<IActionResult> OnGetSortById()
        {
            if (Role.HasValue)
                Users = await _userService.GetUsersByRoleAsync(Role.Value);
            else
                Users = await _userService.GetUsersWithRolesAsync();

            Users.Sort(new IdAscendingComparator());

            return Page();
        }

        public async Task<IActionResult> OnGetSortByIdDesc()
        {
            if (Role.HasValue)
                Users = await _userService.GetUsersByRoleAsync(Role.Value);
            else
                Users = await _userService.GetUsersWithRolesAsync();

            Users.Sort(new IdDescendingComparator());

            return Page();
        }

        public async Task<IActionResult> OnGetSortByName()
        {
            if (Role.HasValue)
                Users = await _userService.GetUsersByRoleAsync(Role.Value);
            else
                Users = await _userService.GetUsersWithRolesAsync();

            Users.Sort(new NameAscendingComparator());

            return Page();
        }

        public async Task<IActionResult> OnGetSortByNameDesc()
        {
            if (Role.HasValue)
                Users = await _userService.GetUsersByRoleAsync(Role.Value);
            else
                Users = await _userService.GetUsersWithRolesAsync();

            Users.Sort(new NameDescendingComparator());

            return Page();
        }

    }
}