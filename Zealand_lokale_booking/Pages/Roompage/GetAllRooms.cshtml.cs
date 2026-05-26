using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.RoomServ;

namespace Zealand_lokale_booking.Pages.Roompage
{
    public class GetAllRoomsModel : PageModel
    {
        private readonly IRoomService _roomService;

        public GetAllRoomsModel(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public List<Room> Rooms { get; set; } = new();

        public async Task OnGetAsync()
        {
            Rooms = await _roomService.GetAllRoomsAsync();
        }
    }
}