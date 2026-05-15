using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.MockData;

public class BookingMock
{
    public static List<Booking> GetBookings()
    {
        return new List<Booking>
        {
            new Booking
            {
                BookingId = 1,
                UserId = 1,
                RoomId = 101,
                BookingDate = DateTime.Today,
                StartTime = DateTime.Today.AddHours(8),
                EndTime = DateTime.Today.AddHours(10),
                Status = true,
                TimeSlotId = 1
            },

            new Booking
            {
                BookingId = 2,
                UserId = 2,
                RoomId = 102,
                BookingDate = DateTime.Today,
                StartTime = DateTime.Today.AddHours(10),
                EndTime = DateTime.Today.AddHours(12),
                Status = true,
                TimeSlotId = 2
            }
        };
    }
}