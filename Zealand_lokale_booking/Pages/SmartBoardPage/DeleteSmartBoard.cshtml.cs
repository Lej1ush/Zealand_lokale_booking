using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.SmartBoardPage
{
    public class DeleteSmartBoardModel : PageModel
    {
        private readonly SmartBoardService _smartBoardService;

        public DeleteSmartBoardModel(SmartBoardService smartBoardService)
        {
            _smartBoardService = smartBoardService;
        }

        public SmartBoard? SmartBoard { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SmartBoard = await _smartBoardService.GetSmartBoardAsync(id);

            if (SmartBoard == null)
            {
                return RedirectToPage("/SmartBoardPage/GetAllSmartBoards");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _smartBoardService.DeleteSmartBoardAsync(id);

            return RedirectToPage("/SmartBoardPage/GetAllSmartBoards");
        }
    }
}