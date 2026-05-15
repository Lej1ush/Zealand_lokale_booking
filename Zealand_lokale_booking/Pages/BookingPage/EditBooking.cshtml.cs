using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.BookingPage;

public class EditBookingModel : PageModel
{
    private readonly BookingService _bookingService;

    [BindProperty]
    public Booking Booking { get; set; }

    public EditBookingModel(BookingService bookingService)
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

    public IActionResult OnPost()
    {
        _bookingService.UpdateBooking(Booking);

        return RedirectToPage("/BookingPage/GetAllBookings");
    }
}