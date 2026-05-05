using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Zealand_lokale_booking.Pages.LogInPage
{
    [Authorize(Roles = "Admin")]
    public class AdminDashBoardModel : PageModel
    {
     
      
            public void OnGet()
            {
            }
        
    }
}
