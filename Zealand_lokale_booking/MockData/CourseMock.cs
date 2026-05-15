using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.MockData;

public class CourseMock
{
    public static List<Course> GetCourses()
    {
        return new List<Course>
        {
            new Course
            {
                CourseId = 1,
                CourseName = "Datamatiker"
            },

            new Course
            {
                CourseId = 2,
                CourseName = "Financial Controller"
            },

            new Course
            {
                CourseId = 3,
                CourseName = "Multimediedesign"
            }
        };
    }
}