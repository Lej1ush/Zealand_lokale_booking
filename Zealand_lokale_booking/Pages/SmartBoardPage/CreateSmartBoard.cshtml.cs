using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.SmartBoardServ;

namespace Zealand_lokale_booking.Pages.SmartBoardPage
{
    public class CreateSmartBoardModel : PageModel
    {
        private readonly ISmartBoardService _smartBoardService;

        public CreateSmartBoardModel(ISmartBoardService smartBoardService)
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
            SmartBoard.Availability = true;

            await _smartBoardService.AddSmartBoardAsync(SmartBoard);

            return RedirectToPage("/SmartBoardPage/GetAllSmartBoards");
        }
    }
}