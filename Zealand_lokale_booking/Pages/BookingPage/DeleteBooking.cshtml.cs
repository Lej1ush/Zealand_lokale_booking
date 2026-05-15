using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.BookingPage;

public class DeleteBookingModel : PageModel
{
    private readonly BookingService _bookingService;

    public Booking? Booking { get; set; }

    public DeleteBookingModel(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public IActionResult OnGet(int id)
    {
        Booking = _bookingService.GetBookingById(id);

        if (Booking == null)
        {
            return RedirectToPage("/BookingPage/GetAllBookings");
        }

        return Page();
    }
    
    public IActionResult OnPost(int id)
    {
        _bookingService.CancelBooking(id);

        return RedirectToPage("/BookingPage/GetAllBookings");
    }
}