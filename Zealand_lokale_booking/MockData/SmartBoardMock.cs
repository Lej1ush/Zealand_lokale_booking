using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.MockData;

public class SmartBoardMock
{
    public static List<SmartBoard> GetSmartBoards()
    {
        return new List<SmartBoard>
        {
            new SmartBoard
            {
                SmartBoardId = 1,
                SmartBoardName = "SB1",
                Availability = true
            },

            new SmartBoard
            {
                SmartBoardId = 2,
                SmartBoardName = "SB2",
                Availability = false
            }
        };
    }
}