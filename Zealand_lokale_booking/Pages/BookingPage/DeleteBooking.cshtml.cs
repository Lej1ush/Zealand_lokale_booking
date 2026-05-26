using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.BookingServ;

namespace Zealand_lokale_booking.Pages.BookingPage
{
    public class DeleteBookingModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public DeleteBookingModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public Booking? Booking { get; set; }

        public string Message { get; set; } = "";

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Booking = await _bookingService.GetBookingByIdAsync(id);

            if (Booking == null)
            {
                return RedirectToPage("/BookingPage/GetAllBookings");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            string? role = User.FindFirstValue(ClaimTypes.Role);

            if (role != "Admin" && role != "Teacher")
            {
                Booking = await _bookingService.GetBookingByIdAsync(id);
                Message = "Kun admin og undervisere kan annullere bookinger.";
                return Page();
            }

            await _bookingService.CancelBookingAsync(id);

            if (!string.IsNullOrEmpty(_bookingService.ErrorMessage))
            {
                Booking = await _bookingService.GetBookingByIdAsync(id);
                Message = _bookingService.ErrorMessage;
                return Page();
            }

            return RedirectToPage("/BookingPage/GetAllBookings");
        }
    }
}