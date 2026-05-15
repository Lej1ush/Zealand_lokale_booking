namespace Zealand_lokale_booking.Models;

public class Booking
{
    public int BookingId { get; set; }
    public int UserId { get; set; }
    public int RoomId { get; set; }

    public DateTime BookingDate { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public bool Status { get; set; }

    public int? TimeSlotId { get; set; }
    public int? BookingPartId { get; set; }

    public Booking()
    {
    }

    public Booking(int bookingId, int userId, int roomId, DateTime startTime, DateTime endTime)
    {
        BookingId = bookingId;
        UserId = userId;
        RoomId = roomId;
        StartTime = startTime;
        EndTime = endTime;
        BookingDate = DateTime.Now;
        Status = true;
    }

    public override string ToString()
    {
        return $"Booking {BookingId}: User {UserId}, Room {RoomId}, {StartTime} - {EndTime}";
    }
}