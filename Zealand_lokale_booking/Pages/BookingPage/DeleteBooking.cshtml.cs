using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.BookingPage
{
    public class DeleteBookingModel : PageModel
    {
        private readonly BookingService _bookingService;

        public Booking? Booking { get; set; }

        public DeleteBookingModel(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

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
            await _bookingService.CancelBookingAsync(id);

            return RedirectToPage("/BookingPage/GetAllBookings");
        }
    }
}