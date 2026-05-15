using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.MockData;

public class BuildingMock
{
    public static List<Building> GetBuildings()
    {
        return new List<Building>
        {
            new Building
            {
                BuildingId = 1,
                BuildingName = "Bygning A",
                Address = "Roskilde"
            },

            new Building
            {
                BuildingId = 2,
                BuildingName = "Bygning B",
                Address = "Køge"
            }
        };
    }
}