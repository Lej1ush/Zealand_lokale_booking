using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.SmartBoardServ;

namespace Zealand_lokale_booking.Pages.SmartBoardPage
{
    public class EditSmartBoardModel : PageModel
    {
        private readonly ISmartBoardService _smartBoardService;

        public EditSmartBoardModel(ISmartBoardService smartBoardService)
        {
            _smartBoardService = smartBoardService;
        }

        [BindProperty]
        public SmartBoard SmartBoard { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var smartBoard = await _smartBoardService.GetSmartBoardByIdAsync(id);

            if (smartBoard == null)
            {
                return RedirectToPage("/SmartBoardPage/GetAllSmartBoards");
            }

            SmartBoard = smartBoard;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _smartBoardService.UpdateSmartBoardAsync(SmartBoard);

            return RedirectToPage("/SmartBoardPage/GetAllSmartBoards");
        }
    }
}