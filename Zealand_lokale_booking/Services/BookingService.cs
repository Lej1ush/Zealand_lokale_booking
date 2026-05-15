using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Repositories;

namespace Zealand_lokale_booking.Services;
public class BookingService
{
    private BookingRepository bookingRepository;

    private static int nextBookingId = 1;

    public BookingService(BookingRepository bookingRepository)
    {
        this.bookingRepository = bookingRepository;
    }

    public Booking CreateBooking(int userId, int roomId, DateTime startTime, DateTime endTime)
    {
        if (!CheckAvailability(roomId, startTime, endTime))
        {
            return null;
        }

        var booking = new Booking(
            nextBookingId++,
            userId,
            roomId,
            startTime,
            endTime
        );

        bookingRepository.Save(booking);
        return booking;
    }

    public void CancelBooking(int bookingId)
    {
        bookingRepository.Delete(bookingId);
    }

    public List<Booking> GetBookingsByUser(int userId)
    {
        return bookingRepository.FindByUser(userId);
    }

    public bool CheckAvailability(int roomId, DateTime startTime, DateTime endTime)
    {
        var bookings = bookingRepository.FindByRoom(roomId);

        foreach (var booking in bookings)
        {
            if (startTime < booking.EndTime && endTime > booking.StartTime)
            {
                return false;
            }
        }

        return true;
    }
    public List<Booking> GetAllBookings()
    {
        return bookingRepository.GetAll();
    }
    public Booking GetBookingById(int id)
    {
        return bookingRepository.FindById(id);
    }
    public void UpdateBooking(Booking updatedBooking)
    {
        Booking booking = GetBookingById(updatedBooking.BookingId);

        if (booking != null)
        {
            booking.UserId = updatedBooking.UserId;
            booking.RoomId = updatedBooking.RoomId;
            booking.StartTime = updatedBooking.StartTime;
            booking.EndTime = updatedBooking.EndTime;
        }
    }
}
