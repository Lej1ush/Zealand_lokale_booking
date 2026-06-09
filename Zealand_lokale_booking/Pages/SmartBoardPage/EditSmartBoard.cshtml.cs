using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.RoomServ;
using Zealand_lokale_booking.Services.SmartBoardServ;

namespace Zealand_lokale_booking.Pages.SmartBoardPage
{
    public class EditSmartBoardModel : PageModel
    {
        private readonly ISmartBoardService _smartBoardService;
        private readonly IRoomService _roomService;

        public EditSmartBoardModel(ISmartBoardService smartBoardService, IRoomService roomService)
        {
            _smartBoardService = smartBoardService;
            _roomService = roomService;
        }

        [BindProperty]
        public SmartBoard SmartBoard { get; set; } = new();

        public SelectList RoomOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var smartBoard = await _smartBoardService.GetSmartBoardByIdAsync(id);

            if (smartBoard == null)
            {
                return RedirectToPage("/SmartBoardPage/GetAllSmartBoards");
            }

            SmartBoard = smartBoard;

            var rooms = await _roomService.GetAllRoomsAsync();
            RoomOptions = new SelectList(rooms, "RoomId", "RoomName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _smartBoardService.UpdateSmartBoardAsync(SmartBoard);

            return RedirectToPage("/SmartBoardPage/GetAllSmartBoards");
        }
    }
}