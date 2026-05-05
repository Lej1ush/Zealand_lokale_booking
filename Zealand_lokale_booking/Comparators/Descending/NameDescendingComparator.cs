using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Comparators.Descending
{
    public class NameDescendingComparator : IComparer<User>
    {
        public int Compare(User? x, User? y)
        {
            if (x == null || y == null)
                return 0;

            return string.Compare( y.Name, x.Name,
                StringComparison.OrdinalIgnoreCase
            );
        }
    }
}
