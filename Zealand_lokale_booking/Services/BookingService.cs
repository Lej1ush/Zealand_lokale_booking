using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Repositories;

namespace Zealand_lokale_booking.Services
{
    public class BookingService
    {
        private readonly BookingRepository bookingRepository;

        public BookingService(BookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task<Booking?> CreateBookingAsync(int userId, int roomId, DateTime startTime, DateTime endTime)
        {
            bool available = await CheckAvailabilityAsync(roomId, startTime, endTime);

            if (!available)
            {
                return null;
            }

            var booking = new Booking
            {
                UserId = userId,
                RoomId = roomId,
                StartTime = startTime,
                EndTime = endTime,
                BookingDate = startTime.Date
            };

            await bookingRepository.AddAsync(booking);
            await bookingRepository.SaveAsync();

            return booking;
        }

        public async Task CancelBookingAsync(int bookingId)
        {
            var booking = await bookingRepository.FindByIdAsync(bookingId);

            if (booking != null)
            {
                bookingRepository.Delete(booking);
                await bookingRepository.SaveAsync();
            }
        }

        public async Task<List<Booking>> GetBookingsByUserAsync(int userId)
        {
            return await bookingRepository.FindByUserAsync(userId);
        }

        public async Task<bool> CheckAvailabilityAsync(int roomId, DateTime startTime, DateTime endTime)
        {
            var bookings = await bookingRepository.FindByRoomAsync(roomId);

            foreach (var booking in bookings)
            {
                if (startTime < booking.EndTime && endTime > booking.StartTime)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await bookingRepository.GetAllAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await bookingRepository.FindByIdAsync(id);
        }

        public async Task UpdateBookingAsync(Booking updatedBooking)
        {
            var booking = await bookingRepository.FindByIdAsync(updatedBooking.BookingId);

            if (booking != null)
            {
                booking.UserId = updatedBooking.UserId;
                booking.RoomId = updatedBooking.RoomId;
                booking.StartTime = updatedBooking.StartTime;
                booking.EndTime = updatedBooking.EndTime;
                booking.BookingDate = updatedBooking.StartTime.Date;

                await bookingRepository.SaveAsync();
            }
        }
    }
}