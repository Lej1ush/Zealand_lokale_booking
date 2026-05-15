using Zealand_lokale_booking.Models;
using System.Linq;

namespace Zealand_lokale_booking.Repositories;

public class BookingRepository
{
    private List<Booking> bookings = new List<Booking>();

    // mock data
    public void SeedData()
    {
        bookings.Add(new Booking(1, 1, 101, DateTime.Now.AddHours(1), DateTime.Now.AddHours(3)));
        bookings.Add(new Booking(2, 2, 102, DateTime.Now.AddHours(2), DateTime.Now.AddHours(4)));
        bookings.Add(new Booking(3, 1, 103, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(2)));
    }

    public Booking FindById(int id)
    {
        return bookings.FirstOrDefault(b => b.BookingId == id);
    }

    public List<Booking> FindByUser(int userId)
    {
        return bookings.Where(b => b.UserId == userId).ToList();
    }

    public List<Booking> FindByRoom(int roomId)
    {
        return bookings.Where(b => b.RoomId == roomId).ToList();
    }

    public List<Booking> FindByDate(DateTime date)
    {
        return bookings.Where(b => b.BookingDate.Date == date.Date).ToList();
    }

    public List<Booking> GetAll()
    {
        return bookings;
    }

    public void Save(Booking booking)
    {
        bookings.Add(booking);
    }

    public void Delete(int id)
    {
        var booking = FindById(id);
        if (booking != null)
        {
            bookings.Remove(booking);
        }
    }
}