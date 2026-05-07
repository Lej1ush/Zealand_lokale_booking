namespace Zealand_lokale_booking.Models;

// BookingPart bruges især til auditorium
// hvor man kan booke enten hel eller halv del
public class BookingPart
{
    public int BookingPartId { get; set; }
    public string PartName { get; set; } // Fx "Hel" eller "Halv"

    // Tom constructor
    public BookingPart()
    {
    }

    // Constructor med værdier
    public BookingPart(int bookingPartId, string partName)
    {
        BookingPartId = bookingPartId;
    }

    public override string ToString()
    {
        return $"{BookingPartId} - {PartName}";
    }
}