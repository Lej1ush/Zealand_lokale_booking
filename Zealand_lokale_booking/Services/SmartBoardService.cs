using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Repositories;

namespace Zealand_lokale_booking.Services
{
    public class SmartBoardService
    {
        private SmartBoardRepository repository;

        public SmartBoardService(SmartBoardRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<SmartBoard>> GetAllSmartBoardsAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<SmartBoard?> GetSmartBoardAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task CreateSmartBoardAsync(SmartBoard smartBoard)
        {
            await repository.AddAsync(smartBoard);
            await repository.SaveAsync();
        }

        public async Task UpdateSmartBoardAsync(SmartBoard smartBoard)
        {
            repository.Update(smartBoard);
            await repository.SaveAsync();
        }

        public async Task DeleteSmartBoardAsync(int id)
        {
            var smartBoard = await repository.GetByIdAsync(id);

            if (smartBoard != null)
            {
                repository.Delete(smartBoard);
                await repository.SaveAsync();
            }
        }
    }
}