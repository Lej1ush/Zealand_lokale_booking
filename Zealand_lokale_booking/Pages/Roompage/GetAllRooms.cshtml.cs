using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.Roompage;

public class GetAllRoomsModel : PageModel
{
    private readonly RoomService _roomService;

    public List<Room> Rooms { get; set; }

    public GetAllRoomsModel(RoomService roomService)
    {
        _roomService = roomService;
    }

    public void OnGet()
    {
        Rooms = _roomService.GetAllRooms();
    }
}