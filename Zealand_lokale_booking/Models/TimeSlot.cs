namespace Zealand_lokale_booking.Models;

// TimeSlot beskriver tidsrummet for en booking
// Fx fra 10:00 til 12:00
public class TimeSlot
{
    public int TimeSlotId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }

    // Tom constructor
    public TimeSlot()
    {
    }

    // Constructor med værdier
    public TimeSlot(int timeSlotId, string startTime, string endTime)
    {
        TimeSlotId = timeSlotId;
        StartTime = startTime;
        EndTime = endTime;
    }

    public override string ToString()
    {
        return $"{StartTime} - {EndTime}";
    }
}