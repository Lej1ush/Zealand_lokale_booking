using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;


namespace Zealand_lokale_booking.Models

{

    public class UserCourse

    {

        [Key]

        public int UserCourseId { get; set; }


        [Required]

        public int UserId { get; set; }


        [Required]

        public int CourseId { get; set; }


        [ForeignKey(nameof(UserId))]

        public User User { get; set; }


        [ForeignKey(nameof(CourseId))]

        public Course Course { get; set; }



        public UserCourse() { }


        public UserCourse(int userId, int courseId)

        {

            UserId = userId;

            CourseId = courseId;

        }

    }

}