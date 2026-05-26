using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Services.SmartBoardServ
{
    public interface ISmartBoardService
    {
        Task<List<SmartBoard>> GetAllSmartBoardsAsync();
        Task<SmartBoard?> GetSmartBoardByIdAsync(int id);
        Task AddSmartBoardAsync(SmartBoard smartBoard);
        Task UpdateSmartBoardAsync(SmartBoard smartBoard);
        Task DeleteSmartBoardAsync(int id);
    }
}