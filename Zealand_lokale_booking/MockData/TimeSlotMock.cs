using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.MockData;

public class TimeSlotMock
{
    public static List<TimeSlot> GetTimeSlots()
    {
        return new List<TimeSlot>
        {
            new TimeSlot
            {
                TimeSlotId = 1,
                StartTime = "08:00",
                EndTime = "10:00"
            },

            new TimeSlot
            {
                TimeSlotId = 2,
                StartTime = "10:00",
                EndTime = "12:00"
            },

            new TimeSlot
            {
                TimeSlotId = 3,
                StartTime = "12:00",
                EndTime = "14:00"
            },

            new TimeSlot
            {
                TimeSlotId = 4,
                StartTime = "14:00",
                EndTime = "16:00"
            }
        };
    }
}