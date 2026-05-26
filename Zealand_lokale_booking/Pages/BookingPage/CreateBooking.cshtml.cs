using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Zealand_lokale_booking.Services.BookingServ;
using Zealand_lokale_booking.Services.RoomServ;

namespace Zealand_lokale_booking.Pages.BookingPage
{
    public class CreateBookingModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public CreateBookingModel(
            IBookingService bookingService,
            IRoomService roomService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }

        [BindProperty]
        public int RoomId { get; set; }

        [BindProperty]
        public DateTime StartTime { get; set; }

        [BindProperty]
        public DateTime EndTime { get; set; }

        [BindProperty]
        public int? BookingPartId { get; set; }

        public string Message { get; set; } = "";

        public List<SelectListItem> RoomOptions { get; set; } = new();

        public List<SelectListItem> BookingPartOptions { get; set; } = new();

        public async Task OnGetAsync(int? roomId)
        {
            var start = DateTime.Now.AddHours(1);

            StartTime = new DateTime(
                start.Year,
                start.Month,
                start.Day,
                start.Hour,
                start.Minute,
                0
            );

            EndTime = StartTime.AddHours(2);

            if (roomId != null)
            {
                RoomId = roomId.Value;
            }

            await LoadDropdownsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await LoadDropdownsAsync();

            string? userIdText = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdText))
            {
                Message = "Du skal være logget ind for at oprette en booking.";
                return Page();
            }

            int userId = int.Parse(userIdText);

            var booking = await _bookingService.CreateBookingAsync(
                userId,
                RoomId,
                StartTime,
                EndTime,
                BookingPartId
            );

            if (booking == null)
            {
                Message = _bookingService.ErrorMessage;
                return Page();
            }

            return RedirectToPage("/BookingPage/GetAllBookings");
        }

        private async Task LoadDropdownsAsync()
        {
            var rooms = await _roomService.GetAllRoomsAsync();

            RoomOptions = rooms
                .Select(r => new SelectListItem
                {
                    Value = r.RoomId.ToString(),
                    Text = $"{r.RoomName} - {r.RoomType?.TypeName} - {r.Capacity} personer"
                })
                .ToList();

            var bookingParts = await _bookingService.GetAllBookingPartsAsync();

            BookingPartOptions = bookingParts
                .Select(p => new SelectListItem
                {
                    Value = p.BookingPartId.ToString(),
                    Text = p.PartName
                })
                .ToList();
        }
    }
}