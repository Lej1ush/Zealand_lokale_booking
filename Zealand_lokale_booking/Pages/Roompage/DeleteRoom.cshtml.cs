using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.RoomServ;

namespace Zealand_lokale_booking.Pages.Roompage
{
    public class DeleteRoomModel : PageModel
    {
        private readonly IRoomService _roomService;

        public Room? Room { get; set; }

        public DeleteRoomModel(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Room = await _roomService.GetRoomAsync(id);

            if (Room == null)
            {
                return RedirectToPage("/Roompage/GetAllRooms");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _roomService.DeleteRoomAsync(id);

            return RedirectToPage("/Roompage/GetAllRooms");
        }
    }
}