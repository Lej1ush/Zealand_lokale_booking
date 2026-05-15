using Zealand_lokale_booking.Models;
using System.Linq;

namespace Zealand_lokale_booking.Repositories;

public class RoomRepository
{
    private List<Room> rooms = new List<Room>();

    public RoomRepository()
    {
        // mockdata
        rooms.Add(new Room(1, "A101", 30, 1, 1, 1));
        rooms.Add(new Room(2, "B202", 10, 2, 1, 2));
        rooms.Add(new Room(3, "C303", 50, 3, 2, 3));
    }

    // Hent alle rooms
    public List<Room> GetAll()
    {
        return rooms;
    }

    // Find room med id
    public Room GetById(int id)
    {
        foreach (var room in rooms)
        {
            if (room.RoomId == id)
            {
                return room;
            }
        }
        return null;
    }

    // Tilføj et room
    public void Add(Room room)
    {
        rooms.Add(room);
    }
}
