namespace Zealand_lokale_booking.Models;

public class Room
{   //Properties
    public int RoomId { get; set; }
    public string RoomName { get; set; }
    public int Capacity { get; set; }
    public int Floor { get; set; }

    public int BuildingId { get; set; }
    public int RoomTypeId { get; set; }
    public int? SmartBoardId { get; set; }

    public Room()
    {
    }
      //Constructor
    public Room(int roomId, string roomName, int capacity, int floor, int buildingId, int roomTypeId)
    {
        RoomId = roomId;
        RoomName = roomName;
        Capacity = capacity;
        Floor = floor;
        BuildingId = buildingId;
        RoomTypeId = roomTypeId;
    }
    //metode
    public override string ToString()
    {
        return $"{RoomName} - Kapacitet: {Capacity}";
    }
}