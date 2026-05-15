using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Services;

namespace Zealand_lokale_booking.Pages.BookingPage
{
    public class CreateBookingModel : PageModel
    {
        private readonly BookingService _bookingService;
        private readonly RoomService _roomService;

        public CreateBookingModel(BookingService bookingService, RoomService roomService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }

        [BindProperty]
        public int UserId { get; set; }

        [BindProperty]
        public int RoomId { get; set; }

        [BindProperty]
        public DateTime StartTime { get; set; }

        [BindProperty]
        public DateTime EndTime { get; set; }

        public string Message { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();

        public void OnGet()
        {
            Rooms = _roomService.GetAllRooms();
        }

        public IActionResult OnPost()
        {
            Rooms = _roomService.GetAllRooms();

            var booking = _bookingService.CreateBooking(
                UserId,
                RoomId,
                StartTime,
                EndTime
            );

            if (booking == null)
            {
                Message = "Lokalet er allerede booket i dette tidsrum.";
                return Page();
            }

            return RedirectToPage("/BookingPage/GetAllBookings");
        }
    }
}