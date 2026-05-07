namespace Zealand_lokale_booking.Models;

// RoomType beskriver hvilken type lokale der er tale om
// Fx klasselokale, mødelokale eller auditorium
public class RoomType
{
    public int RoomTypeId { get; set; }
    public string TypeName { get; set; }

    // Tom constructor
    public RoomType()
    {
    }

    // Constructor med værdier
    public RoomType(int roomTypeId, string typeName)
    {
        RoomTypeId = roomTypeId;
        TypeName = typeName;
    }

    public override string ToString()
    {
        return $"{RoomTypeId} - {TypeName}";
    }
}