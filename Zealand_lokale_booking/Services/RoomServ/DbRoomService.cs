using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Repositories;

namespace Zealand_lokale_booking.Services.RoomServ
{
    public class DbRoomService : IRoomService
    {
        private readonly RoomRepository _repository;

        public DbRoomService(RoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Room?> GetRoomAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateRoomAsync(Room room)
        {
            await _repository.AddAsync(room);
            await _repository.SaveAsync();
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _repository.Update(room);
            await _repository.SaveAsync();
        }

        public async Task DeleteRoomAsync(int id)
        {
            var room = await _repository.GetByIdAsync(id);

            if (room != null)
            {
                _repository.Delete(room);
                await _repository.SaveAsync();
            }
        }

        public async Task<List<SmartBoard>> GetAllSmartBoardsAsync()
        {
            return await _repository.GetAllSmartBoardsAsync();
        }

        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            return await _repository.GetAllRoomTypesAsync();
        }

        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            return await _repository.GetAllBuildingsAsync();
        }
    }
}