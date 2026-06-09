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

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                    .ThenInclude(r => r.RoomType)
                .Include(b => b.Room)
                    .ThenInclude(r => r.Building)
                .Include(b => b.BookingPart)
                .ToListAsync();
        }

        public async Task<Booking?> FindByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                    .ThenInclude(r => r.RoomType)
                .Include(b => b.Room)
                    .ThenInclude(r => r.Building)
                .Include(b => b.BookingPart)
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task<List<Booking>> FindByUserAsync(int userId)
        {
            return await _context.Bookings
                .Include(b => b.Room)
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<Booking>> FindByRoomAsync(int roomId)
        {
            return await _context.Bookings
                .Where(b => b.RoomId == roomId)
                .ToListAsync();
        }

        public async Task<List<Booking>> FindByDateAsync(DateTime date)
        {
            return await _context.Bookings
                .Where(b => b.BookingDate.Date == date.Date)
                .ToListAsync();
        }

        public async Task<List<BookingPart>> GetAllBookingPartsAsync()
        {
            return await _context.BookingParts.ToListAsync();
        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        public void Delete(Booking booking)
        {
            _context.Bookings.Remove(booking);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}