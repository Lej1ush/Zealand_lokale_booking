namespace Zealand_lokale_booking.Models;

public class Room
{
    public int RoomId { get; set; }

    public string RoomName { get; set; }

    public int Capacity { get; set; }

    public int Floor { get; set; }

    public int BuildingId { get; set; }

    public int RoomTypeId { get; set; }

    public Building? Building { get; set; }

    public RoomType? RoomType { get; set; }

    public Room()
    {
    }

    public Room(
        int roomId,
        string roomName,
        int capacity,
        int floor,
        int buildingId,
        int roomTypeId)
    {
        RoomId = roomId;
        RoomName = roomName;
        Capacity = capacity;
        Floor = floor;
        BuildingId = buildingId;
        RoomTypeId = roomTypeId;
    }

    public override string ToString()
    {
        return $"{RoomName} - Kapacitet: {Capacity}";
    }
}