using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.Roompage
{
    public class CreateRoomModel : PageModel
    {
        private readonly RoomService _roomService;

        public CreateRoomModel(RoomService roomService)
        {
            _roomService = roomService;
        }

        [BindProperty]
        public Room Room { get; set; } = new();

        public List<SelectListItem> BuildingOptions { get; set; } = new();

        public List<SelectListItem> RoomTypeOptions { get; set; } = new();

        public List<SelectListItem> SmartBoardOptions { get; set; } = new();

        public async Task OnGetAsync()
        {
            await LoadDropdownsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await LoadDropdownsAsync();

            await _roomService.CreateRoomAsync(Room);

            return RedirectToPage("/Roompage/GetAllRooms");
        }

        private async Task LoadDropdownsAsync()
        {
            var buildings = await _roomService.GetAllBuildingsAsync();

            BuildingOptions = buildings
                .Select(b => new SelectListItem
                {
                    Value = b.BuildingId.ToString(),
                    Text = b.BuildingName
                })
                .ToList();

            var roomTypes = await _roomService.GetAllRoomTypesAsync();

            RoomTypeOptions = roomTypes
                .Select(r => new SelectListItem
                {
                    Value = r.RoomTypeId.ToString(),
                    Text = r.TypeName
                })
                .ToList();

            var smartBoards = await _roomService.GetAllSmartBoardsAsync();

            SmartBoardOptions = smartBoards
                .Select(s => new SelectListItem
                {
                    Value = s.SmartBoardId.ToString(),
                    Text = s.SmartBoardName
                })
                .ToList();
        }
    }
}