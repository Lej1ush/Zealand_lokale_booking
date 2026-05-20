using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Repositories;

namespace Zealand_lokale_booking.Pages.Roompage
{
    public class CreateRoomModel : PageModel
    {
        private readonly RoomRepository _repo;

        public CreateRoomModel(RoomRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Room Room { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _repo.AddAsync(Room);
            await _repo.SaveAsync();

            return RedirectToPage("GetAllRooms");
        }
    }
}