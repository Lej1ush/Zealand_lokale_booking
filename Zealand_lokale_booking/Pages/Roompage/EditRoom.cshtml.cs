using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.RoomServ;

namespace Zealand_lokale_booking.Pages.Roompage
{
    public class EditRoomModel : PageModel
    {
        private readonly IRoomService _roomService;

        public EditRoomModel(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [BindProperty]
        public Room Room { get; set; } = new();

        public List<SelectListItem> SmartBoardOptions { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Room = await _roomService.GetRoomAsync(id);

            if (Room == null)
            {
                return RedirectToPage("/Roompage/GetAllRooms");
            }

            await LoadSmartBoardsAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _roomService.UpdateRoomAsync(Room);

            return RedirectToPage("/Roompage/GetAllRooms");
        }

        private async Task LoadSmartBoardsAsync()
        {
            var smartBoards = await _roomService.GetAllSmartBoardsAsync();

            SmartBoardOptions = smartBoards.Select(s => new SelectListItem
            {
                Value = s.SmartBoardId.ToString(),
                Text = s.SmartBoardName
            }).ToList();
        }
    }
}