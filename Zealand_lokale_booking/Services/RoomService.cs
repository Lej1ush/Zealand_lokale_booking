using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Repositories;

namespace Zealand_lokale_booking.Services;
public class RoomService
{
    private RoomRepository repository;

    public RoomService(RoomRepository repository)
    {
        this.repository = repository;
    }

    // Hent alle rooms
    public List<Room> GetAllRooms()
    {
        return repository.GetAll();
    }

    // Hent room med id
    public Room GetRoom(int id)
    {
        return repository.GetById(id);
    }

    // Tilføj room
    public void CreateRoom(Room room)
    {
        repository.Add(room);
    }
}
