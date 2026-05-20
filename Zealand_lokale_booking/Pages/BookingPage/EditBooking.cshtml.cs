using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.BookingPage
{
    public class EditBookingModel : PageModel
    {
        private readonly BookingService _bookingService;

        [BindProperty]
        public Booking Booking { get; set; } = new();

        public EditBookingModel(BookingService bookingService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookingService.UpdateBookingAsync(Booking);

            return RedirectToPage("/BookingPage/GetAllBookings");
        }
    }
}