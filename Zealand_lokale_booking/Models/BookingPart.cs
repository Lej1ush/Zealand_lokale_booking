namespace Zealand_lokale_booking.Models;

public class BookingPart
{
    public int BookingPartId { get; set; }

    public string PartName { get; set; } = "";

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public BookingPart()
    {
    }

    public BookingPart(int bookingPartId, string partName)
    {
        BookingPartId = bookingPartId;
        PartName = partName;
    }

    public override string ToString()
    {
        return PartName;
    }
}