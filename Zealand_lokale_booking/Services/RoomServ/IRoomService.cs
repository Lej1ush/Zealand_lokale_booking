using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Services.RoomServ
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllRoomsAsync();
        Task<Room?> GetRoomAsync(int id);
        Task CreateRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(int id);

        Task<List<SmartBoard>> GetAllSmartBoardsAsync();
        Task<List<RoomType>> GetAllRoomTypesAsync();
        Task<List<Building>> GetAllBuildingsAsync();
    }
}