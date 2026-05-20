using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Repositories;

namespace Zealand_lokale_booking.Services
{
    public class RoomService
    {
        private RoomRepository repository;

        public RoomService(RoomRepository repository)
        {
            this.repository = repository;
        }

        // Hent alle rooms
        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await repository.GetAllAsync();
        }

        // Hent room med id
        public async Task<Room?> GetRoomAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        // Tilføj room
        public async Task CreateRoomAsync(Room room)
        {
            await repository.AddAsync(room);
            await repository.SaveAsync();
        }
    }
}