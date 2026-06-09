using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Comparators.Ascending
{
    public class NameAscendingComparator : IComparer<User>
    {
        
            public int Compare(User? x, User? y)
            {
                return string.Compare(
                    x?.Name,
                    y?.Name,
                    StringComparison.OrdinalIgnoreCase);
            }
        
    }
}
