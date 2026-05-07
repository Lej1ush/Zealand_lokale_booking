namespace Zealand_lokale_booking.MockData;

public class BuildingMock
{
    public static List<Building> GetBuildings()
    {
        return new List<Building>
        {
            new Building { Id = 1, Name = "Bygning A", Address = "Roskilde" },
            new Building { Id = 2, Name = "Bygning B", Address = "Køge" }
        };
    }
}
