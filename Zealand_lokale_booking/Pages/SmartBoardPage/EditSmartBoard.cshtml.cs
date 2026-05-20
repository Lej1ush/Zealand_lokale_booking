using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.SmartBoardPage
{
    public class EditSmartBoardModel : PageModel
    {
        private readonly SmartBoardService _smartBoardService;

        public EditSmartBoardModel(
            SmartBoardService smartBoardService)
        {
            _smartBoardService = smartBoardService;
        }

        [BindProperty]
        public SmartBoard SmartBoard { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SmartBoard =
                await _smartBoardService.GetSmartBoardAsync(id);

            if (SmartBoard == null)
            {
                return RedirectToPage(
                    "/SmartBoardPage/GetAllSmartBoards");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _smartBoardService.UpdateSmartBoardAsync(
                SmartBoard);

            return RedirectToPage(
                "/SmartBoardPage/GetAllSmartBoards");
        }
    }
}