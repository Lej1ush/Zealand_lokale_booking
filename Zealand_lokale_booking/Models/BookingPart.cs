namespace Zealand_lokale_booking.Models;

// BookingPart bruges især til auditorium
// hvor man kan booke enten hel eller halv del

public class BookingPart
{
    public int BookingPartId { get; set; }
    public string PartName { get; set; }

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