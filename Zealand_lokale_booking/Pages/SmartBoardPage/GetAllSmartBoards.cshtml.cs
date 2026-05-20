using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.SmartBoardPage
{
    public class GetAllSmartBoardsModel : PageModel
    {
        private readonly SmartBoardService _smartBoardService;

        public GetAllSmartBoardsModel(
            SmartBoardService smartBoardService)
        {
            _smartBoardService = smartBoardService;
        }

        public List<SmartBoard> SmartBoards { get; set; } = new();

        public async Task OnGetAsync()
        {
            SmartBoards =
                await _smartBoardService.GetAllSmartBoardsAsync();
        }
    }
}