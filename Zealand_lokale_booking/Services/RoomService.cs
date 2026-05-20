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

        // Hent SmartBoards
        public async Task<List<SmartBoard>> GetAllSmartBoardsAsync()
        {
            return await repository.GetAllSmartBoardsAsync();
        }
        
        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            return await repository.GetAllBuildingsAsync();
        }

        // Hent RoomTypes
        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            return await repository.GetAllRoomTypesAsync();
        }

        // Opdater room
        public async Task UpdateRoomAsync(Room room)
        {
            repository.Update(room);
            await repository.SaveAsync();
        }

        // Slet room
        public async Task DeleteRoomAsync(int id)
        {
            var room = await repository.GetByIdAsync(id);

            if (room != null)
            {
                repository.Delete(room);
                await repository.SaveAsync();
            }
        }
    }
}