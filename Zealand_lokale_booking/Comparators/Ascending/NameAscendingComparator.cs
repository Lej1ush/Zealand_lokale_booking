using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Comparators.Ascending
{
    public class NameAscendingComparator : IComparer<User>
    {
        public int Compare(User? x, User? y)
        {
            if (x == null || y == null)
                return 0;

            return string.Compare(x.Name, y.Name);
        }
    }
}
