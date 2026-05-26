using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.BookingServ;

namespace Zealand_lokale_booking.Pages.BookingPage
{
    public class EditBookingModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public EditBookingModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty]
        public Booking Booking { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);

            if (booking == null)
            {
                return RedirectToPage("/BookingPage/GetAllBookings");
            }

            Booking = booking;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookingService.UpdateBookingAsync(Booking);

            return RedirectToPage("/BookingPage/GetAllBookings");
        }
    }
}