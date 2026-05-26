using Microsoft.EntityFrameworkCore;
using Zealand_lokale_booking.EFDbContext;
using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Repositories
{
    public class BookingRepository
    {
        private readonly UserDbContext _context;

        public BookingRepository(UserDbContext context)
        {
            _context = context;
        }

        // Hent alle bookinger inkl. relationer
        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                    .ThenInclude(r => r.RoomType)
                .Include(b => b.Room)
                    .ThenInclude(r => r.Building)
                .Include(b => b.Room)
                    .ThenInclude(r => r.SmartBoard)
                .Include(b => b.BookingPart)
                .ToListAsync();
        }

        // Hent booking efter id
        public async Task<Booking?> FindByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                    .ThenInclude(r => r.RoomType)
                .Include(b => b.Room)
                    .ThenInclude(r => r.Building)
                .Include(b => b.Room)
                    .ThenInclude(r => r.SmartBoard)
                .Include(b => b.BookingPart)
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        // Hent bookinger efter bruger
        public async Task<List<Booking>> FindByUserAsync(int userId)
        {
            return await _context.Bookings
                .Include(b => b.Room)
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        // Hent bookinger efter lokale
        public async Task<List<Booking>> FindByRoomAsync(int roomId)
        {
            return await _context.Bookings
                .Where(b => b.RoomId == roomId)
                .ToListAsync();
        }

        // Hent bookinger efter dato
        public async Task<List<Booking>> FindByDateAsync(DateTime date)
        {
            return await _context.Bookings
                .Where(b => b.BookingDate.Date == date.Date)
                .ToListAsync();
        }

        // Hent alle booking parts
        public async Task<List<BookingPart>> GetAllBookingPartsAsync()
        {
            return await _context.BookingParts.ToListAsync();
        }

        // Opret booking
        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        // Slet booking
        public void Delete(Booking booking)
        {
            _context.Bookings.Remove(booking);
        }

        // Gem ændringer
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}