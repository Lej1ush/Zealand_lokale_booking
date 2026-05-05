using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Comparators.Descending
{
    public class IdDescendingComparator : IComparer<User>
    {
        public int Compare(User? x, User? y)
        {
            if (x == null || y == null)
                return 0;

            return y.UserId.CompareTo(x.UserId);
        }
    }
}
