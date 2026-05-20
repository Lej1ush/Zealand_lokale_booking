using Microsoft.EntityFrameworkCore;
using Zealand_lokale_booking.EFDbContext;
using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Repositories
{
    public class RoomRepository
    {
        private readonly UserDbContext _context;

        public RoomRepository(UserDbContext context)
        {
            _context = context;
        }

        // Hent alle lokaler inkl. SmartBoard
        public async Task<List<Room>> GetAllAsync()
        {
            return await _context.Rooms
                .Include(r => r.SmartBoard)
                .ToListAsync();
        }

        // Hent lokale efter id inkl. SmartBoard
        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms
                .Include(r => r.SmartBoard)
                .FirstOrDefaultAsync(r => r.RoomId == id);
        }

        // Tilføj lokale
        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
        }

        // Gem ændringer
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}