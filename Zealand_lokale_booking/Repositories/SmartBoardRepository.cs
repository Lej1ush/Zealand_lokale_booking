using Microsoft.EntityFrameworkCore;
using Zealand_lokale_booking.EFDbContext;
using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Repositories
{
    public class SmartBoardRepository
    {
        private readonly UserDbContext _context;

        public SmartBoardRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<List<SmartBoard>> GetAllAsync()
        {
            return await _context.SmartBoards.ToListAsync();
        }

        public async Task<SmartBoard?> GetByIdAsync(int id)
        {
            return await _context.SmartBoards
                .FirstOrDefaultAsync(s => s.SmartBoardId == id);
        }

        public async Task AddAsync(SmartBoard smartBoard)
        {
            await _context.SmartBoards.AddAsync(smartBoard);
        }

        public void Update(SmartBoard smartBoard)
        {
            _context.SmartBoards.Update(smartBoard);
        }

        public void Delete(SmartBoard smartBoard)
        {
            _context.SmartBoards.Remove(smartBoard);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}