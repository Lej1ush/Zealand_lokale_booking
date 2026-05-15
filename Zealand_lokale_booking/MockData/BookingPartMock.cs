using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.MockData;

public class BookingPartMock
{
    public static List<BookingPart> GetBookingParts()
    {
        return new List<BookingPart>
        {
            new BookingPart
            {
                BookingPartId = 1,
                PartName = "Hel"
            },

            new BookingPart
            {
                BookingPartId = 2,
                PartName = "Halv"
            }
        };
    }
}