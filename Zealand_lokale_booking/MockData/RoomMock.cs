using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.MockData;

public class RoomMock
{
    public static List<Room> GetRooms()
    {
        return new List<Room>
        {
            new Room
            {
                RoomId = 1,
                RoomName = "A101",
                Capacity = 30,
                Floor = 1,
                BuildingId = 1,
                RoomTypeId = 1
            },

            new Room
            {
                RoomId = 2,
                RoomName = "B202",
                Capacity = 10,
                Floor = 2,
                BuildingId = 1,
                RoomTypeId = 2
            },

            new Room
            {
                RoomId = 3,
                RoomName = "C303",
                Capacity = 50,
                Floor = 3,
                BuildingId = 2,
                RoomTypeId = 3
            }
        };
    }
}