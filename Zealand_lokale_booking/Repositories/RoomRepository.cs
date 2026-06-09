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

        public async Task<List<Room>> GetAllAsync()
        {
            return await _context.Rooms
                .Include(r => r.Building)
                .Include(r => r.RoomType)
                .ToListAsync();
        }

        public async Task<List<SmartBoard>> GetAllSmartBoardsAsync()
        {
            return await _context.SmartBoards
                .Include(s => s.Room)
                .ToListAsync();
        }

        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            return await _context.Buildings.ToListAsync();
        }

        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms
                .Include(r => r.Building)
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(r => r.RoomId == id);
        }

        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
        }

        public void Update(Room room)
        {
            _context.Rooms.Update(room);
        }

        public void Delete(Room room)
        {
            _context.Rooms.Remove(room);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}