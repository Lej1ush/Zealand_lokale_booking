using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services.BookingServ;

namespace Zealand_lokale_booking.Pages.BookingPage
{
    public class GetAllBookingsModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public List<Booking> Bookings { get; set; } = new();

        public GetAllBookingsModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task OnGetAsync()
        {
            Bookings = await _bookingService.GetAllBookingsAsync();
        }
    }
}