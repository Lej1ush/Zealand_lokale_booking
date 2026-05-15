using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.MockData;

public class UserCoursesMock
{
    public static List<UserCourse> GetUserCourses()
    {
        return new List<UserCourse>
        {
            new UserCourse
            {
                UserId = 1,
                CourseId = 1
            },

            new UserCourse
            {
                UserId = 2,
                CourseId = 2
            },

            new UserCourse
            {
                UserId = 3,
                CourseId = 1
            }
        };
    }
}
