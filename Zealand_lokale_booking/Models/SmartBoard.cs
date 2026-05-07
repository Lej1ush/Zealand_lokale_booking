namespace Zealand_lokale_booking.Models;

// Smartboard beskriver et smartboard i et lokale
public class Smartboard
{
    public int SmartboardId { get; set; }
    public string SmartboardName { get; set; }
    public bool Availability { get; set; }

    // Tom constructor
    public Smartboard()
    {
    }

    // Constructor med værdier
    public Smartboard(int smartboardId, string smartboardName, bool availability)
    {
        SmartboardId = smartboardId;
        SmartboardName = smartboardName;
        Availability = availability;
    }

    public override string ToString()
    {
        return $"{SmartboardName} - Tilgængelig: {Availability}";
    }
}