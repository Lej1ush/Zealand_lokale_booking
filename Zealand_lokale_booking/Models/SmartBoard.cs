namespace Zealand_lokale_booking.Models;

public class SmartBoard
{
    public int SmartBoardId { get; set; }

    public string SmartBoardName { get; set; }

    public int SizeInches { get; set; }

    public string Description { get; set; }

    public bool Availability { get; set; }

    public int? RoomId { get; set; }

    public Room? Room { get; set; }

    public SmartBoard()
    {
    }

    public SmartBoard(int smartBoardId, string smartBoardName, int sizeInches, string description, bool availability, int? roomId = null)
    {
        SmartBoardId = smartBoardId;
        SmartBoardName = smartBoardName;
        SizeInches = sizeInches;
        Description = description;
        Availability = availability;
        RoomId = roomId;
    }

    public override string ToString()
    {
        return $"{SmartBoardName} - {SizeInches}\" - {(Availability ? "Tilgængelig" : "Ikke tilgængelig")}";
    }
}