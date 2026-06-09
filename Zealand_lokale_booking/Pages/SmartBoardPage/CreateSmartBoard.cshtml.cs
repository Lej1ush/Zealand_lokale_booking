using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.RoomServ;
using Zealand_lokale_booking.Services.SmartBoardServ;

namespace Zealand_lokale_booking.Pages.SmartBoardPage
{
    public class CreateSmartBoardModel : PageModel
    {
        private readonly ISmartBoardService _smartBoardService;
        private readonly IRoomService _roomService;

        public CreateSmartBoardModel(ISmartBoardService smartBoardService, IRoomService roomService)
        {
            _smartBoardService = smartBoardService;
            _roomService = roomService;
        }

        [BindProperty]
        public SmartBoard SmartBoard { get; set; } = new();

        public SelectList RoomOptions { get; set; }

        public async Task OnGetAsync()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            RoomOptions = new SelectList(rooms, "RoomId", "RoomName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            RoomOptions = new SelectList(rooms, "RoomId", "RoomName");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            SmartBoard.Availability = true;

            await _smartBoardService.AddSmartBoardAsync(SmartBoard);

            return RedirectToPage("/SmartBoardPage/GetAllSmartBoards");
        }
    }
}