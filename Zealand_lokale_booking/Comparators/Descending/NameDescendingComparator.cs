using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Comparators.Descending
{
    public class NameDescendingComparator : IComparer<User>
    {
        public int Compare(User? x, User? y)
        {
            return string.Compare(
                y?.Name,
                x?.Name,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}

