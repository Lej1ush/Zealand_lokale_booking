namespace Zealand_lokale_booking.Models;

public class Building
{
    public int BuildingId { get; set; }
    public string BuildingName { get; set; }
    public string Address { get; set; }

    public Building()
    {
    }

    public Building(int buildingId, string buildingName, string address)
    {
        BuildingId = buildingId;
        BuildingName = buildingName;
        Address = address;
    }

    public override string ToString()
    {
        return $"{BuildingName} - {Address}";
    }
}