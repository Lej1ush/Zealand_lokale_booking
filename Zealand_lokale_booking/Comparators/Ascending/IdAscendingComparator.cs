using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Comparators.Ascending
{
    public class IdAscendingComparator : IComparer<User>
    {
        public int Compare(User? x, User? y)
        {
            if (x == null || y == null)
                return 0;

            return x.UserId.CompareTo(y.UserId);
        }

    }
}
