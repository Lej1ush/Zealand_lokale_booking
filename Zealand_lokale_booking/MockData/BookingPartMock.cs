namespace Zealand_lokale_booking.MockData;

public class BookingPartMock
{
    public static List<BookingPart> GetBookingParts()
    {
        return new List<BookingPart>
        {
            new BookingPart(1, "Hel"),
            new BookingPart(2, "Halv")
        };
    }
}
