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
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking?> FindByIdAsync(int id)
        {
            return await _context.Bookings
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task<List<Booking>> FindByUserAsync(int userId)
        {
            return await _context.Bookings
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