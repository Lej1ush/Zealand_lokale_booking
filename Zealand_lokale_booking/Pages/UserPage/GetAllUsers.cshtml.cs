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

//        public List<User> Users { get; set; } = new List<User>();

//        public GetAllUsersModel(IUserService userService)
//        {
//            _userService = userService;
//        }

//        [BindProperty]
//        public string SearchString { get; set; }

//        [BindProperty]
//        public int? SearchId { get; set; }
//        [BindProperty(SupportsGet = true)]
//        public RoleType? Role { get; set; }
//        public void OnGet()
//        {
//            if (Role.HasValue)
//            {
//                Users = _userService.GetUsersByRole(Role.Value);
//            }
//            else
//            {
//                Users = _userService.GetAllUsers();
//            }
//        }

//        public IActionResult OnPostNameSearch()
//        {
//            Users = _userService.GetAllUsers()
//                .Where(u => u.Name != null &&
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

 
    public class GetAllUsersModel : PageModel
    {
        private readonly IDbUserService _userService;

        public List<User> Users { get; set; } = new List<User>();

        public GetAllUsersModel(IDbUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string SearchString { get; set; }

        [BindProperty]
        public int? SearchId { get; set; }

        [BindProperty(SupportsGet = true)]
        public RoleType? Role { get; set; }

        public async Task OnGetAsync()
        {
            if (Role.HasValue)
            {
                Users = await _userService.GetUsersByRoleAsync(Role.Value);
            }
            else
            {
                Users = await _userService.GetAllUsersAsync();
            }
        }

        public async Task<IActionResult> OnPostNameSearchAsync()
        {
            var allUsers = await _userService.GetAllUsersAsync();

            Users = allUsers
                .Where(u => u.Name != null &&
                            !string.IsNullOrEmpty(SearchString) &&
                            u.Name.ToLower().Contains(SearchString.ToLower()))
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostIdSearchAsync()
        {
            var allUsers = await _userService.GetAllUsersAsync();

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

        public async Task<IActionResult> OnGetSortByIdAsync()
        {
            Users = await _userService.GetAllUsersAsync();
            Users.Sort(new IdAscendingComparator());
            return Page();
        }

        public async Task<IActionResult> OnGetSortByIdDescAsync()
        {
            Users = await _userService.GetAllUsersAsync();
            Users.Sort(new IdDescendingComparator());
            return Page();
        }

        public async Task<IActionResult> OnGetSortByNameAsync()
        {
            Users = await _userService.GetAllUsersAsync();
            Users.Sort(new NameAscendingComparator());
            return Page();
        }

        public async Task<IActionResult> OnGetSortByNameDescAsync()
        {
            Users = await _userService.GetAllUsersAsync();
            Users.Sort(new NameDescendingComparator());
            return Page();
        }
    }
}