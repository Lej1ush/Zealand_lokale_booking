using System.ComponentModel.DataAnnotations;


namespace Zealand_lokale_booking.Models

{

    public class Course

    {

        [Key]

        public int CourseId { get; set; }


        [Required]

        public string CourseName { get; set; } = "";


// Navigation property

        public ICollection<UserCourse> UserCourses { get; set; }

            = new List<UserCourse>();



        public Course() { }


        public Course(string courseName)

        {

            CourseName = courseName;

        }

    }

}