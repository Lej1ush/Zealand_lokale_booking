using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Services.BookingServ
{
    public interface IBookingService
    {
        string ErrorMessage { get; }

        Task<List<Booking>> GetAllBookingsAsync();
        Task<Booking?> GetBookingByIdAsync(int id);
        Task<List<Booking>> GetBookingsByUserAsync(int userId);

        Task<Booking?> CreateBookingAsync(
            int userId,
            int roomId,
            DateTime startTime,
            DateTime endTime,
            int? bookingPartId);

        Task UpdateBookingAsync(Booking booking);
        Task CancelBookingAsync(int bookingId);

        Task<bool> CheckAvailabilityAsync(
            int roomId,
            DateTime startTime,
            DateTime endTime,
            int? bookingPartId);

        Task<List<Room>> GetAllRoomsAsync();
        Task<List<User>> GetAllUsersAsync();
        Task<List<BookingPart>> GetAllBookingPartsAsync();
    }
}