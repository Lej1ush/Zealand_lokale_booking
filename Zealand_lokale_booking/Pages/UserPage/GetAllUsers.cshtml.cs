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
            var allUsers = await _userService.GetAllUsersAsync();

            Users = allUsers
                .Where(u => u.Name != null &&
                            !string.IsNullOrEmpty(SearchString) &&
                            u.Name.ToLower().Contains(SearchString.ToLower()))
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostIdSearch()
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

        public async Task<IActionResult> OnGetSortById()
        {
            Users = await _userService.GetAllUsersAsync();
            Users.Sort(new IdAscendingComparator());

            return Page();
        }

        public async Task<IActionResult> OnGetSortByIdDesc()
        {
            Users = await _userService.GetAllUsersAsync();
            Users.Sort(new IdDescendingComparator());

            return Page();
        }

        public async Task<IActionResult> OnGetSortByName()
        {
            Users = await _userService.GetAllUsersAsync();
            Users.Sort(new NameAscendingComparator());

            return Page();
        }

        public async Task<IActionResult> OnGetSortByNameDesc()
        {
            Users = await _userService.GetAllUsersAsync();
            Users.Sort(new NameDescendingComparator());

            return Page();
        }
    }
}