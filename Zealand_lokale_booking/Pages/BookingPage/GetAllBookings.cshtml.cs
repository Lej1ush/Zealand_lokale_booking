using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.BookingPage;

public class GetAllBookingsModel : PageModel
{
    private readonly BookingService _bookingService;

    public List<Booking> Bookings { get; set; } = new List<Booking>();

    public GetAllBookingsModel(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public void OnGet()
    {
        Bookings = _bookingService.GetAllBookings();
    }
}