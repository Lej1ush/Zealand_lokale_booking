namespace Zealand_lokale_booking.Models;

public class SmartBoard
{
    public int SmartBoardId { get; set; }
    public string SmartBoardName { get; set; }
    public bool Availability { get; set; }

    public SmartBoard()
    {
    }

    public SmartBoard(int smartBoardId, string smartBoardName, bool availability)
    {
        SmartBoardId = smartBoardId;
        SmartBoardName = smartBoardName;
        Availability = availability;
    }

    public override string ToString()
    {
        return $"{SmartBoardName} - Tilgængelig: {Availability}";
    }
}