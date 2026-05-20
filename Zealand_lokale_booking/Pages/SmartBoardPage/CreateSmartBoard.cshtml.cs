using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.SmartBoardPage
{
    public class CreateSmartBoardModel : PageModel
    {
        private readonly SmartBoardService _smartBoardService;

        public CreateSmartBoardModel(SmartBoardService smartBoardService)
        {
            _smartBoardService = smartBoardService;
        }

        [BindProperty]
        public SmartBoard SmartBoard { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _smartBoardService.CreateSmartBoardAsync(SmartBoard);

            return RedirectToPage("/SmartBoardPage/GetAllSmartBoards");
        }
    }
}