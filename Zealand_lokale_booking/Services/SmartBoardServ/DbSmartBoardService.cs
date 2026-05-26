using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Repositories;

namespace Zealand_lokale_booking.Services.SmartBoardServ
{
    public class DbSmartBoardService : ISmartBoardService
    {
        private readonly SmartBoardRepository _smartBoardRepository;

        public DbSmartBoardService(SmartBoardRepository smartBoardRepository)
        {
            _smartBoardRepository = smartBoardRepository;
        }

        public async Task<List<SmartBoard>> GetAllSmartBoardsAsync()
        {
            return await _smartBoardRepository.GetAllAsync();
        }

        public async Task<SmartBoard?> GetSmartBoardByIdAsync(int id)
        {
            return await _smartBoardRepository.GetByIdAsync(id);
        }

        public async Task AddSmartBoardAsync(SmartBoard smartBoard)
        {
            await _smartBoardRepository.AddAsync(smartBoard);
            await _smartBoardRepository.SaveAsync();
        }

        public async Task UpdateSmartBoardAsync(SmartBoard smartBoard)
        {
            _smartBoardRepository.Update(smartBoard);
            await _smartBoardRepository.SaveAsync();
        }

        public async Task DeleteSmartBoardAsync(int id)
        {
            var smartBoard = await _smartBoardRepository.GetByIdAsync(id);

            if (smartBoard != null)
            {
                _smartBoardRepository.Delete(smartBoard);
                await _smartBoardRepository.SaveAsync();
            }
        }
    }
}