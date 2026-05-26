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

        // Hent alle lokaler inkl. Building, RoomType og SmartBoard
        public async Task<List<Room>> GetAllAsync()
        {
            return await _context.Rooms
                .Include(r => r.Building)
                .Include(r => r.RoomType)
                .Include(r => r.SmartBoard)
                .ToListAsync();
        }

        // Hent alle SmartBoards
        public async Task<List<SmartBoard>> GetAllSmartBoardsAsync()
        {
            return await _context.SmartBoards.ToListAsync();
        }

        // Hent alle bygninger
        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            return await _context.Buildings.ToListAsync();
        }

        // Hent alle lokaletyper
        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        // Hent lokale efter id inkl. Building, RoomType og SmartBoard
        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms
                .Include(r => r.Building)
                .Include(r => r.RoomType)
                .Include(r => r.SmartBoard)
                .FirstOrDefaultAsync(r => r.RoomId == id);
        }

        // Opret lokale
        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
        }

        // Opdater lokale
        public void Update(Room room)
        {
            _context.Rooms.Update(room);
        }

        // Slet lokale
        public void Delete(Room room)
        {
            _context.Rooms.Remove(room);
        }

        // Gem ændringer
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}