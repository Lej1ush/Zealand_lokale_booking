//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Zealand_lokale_booking.Models;

//namespace Zealand_lokale_booking.Models
//{
//    public class User
//    {

//        public int UserId { get; set; }

//        public string Name { get; set; } = "";

//        public string Email { get; set; } = "";

//        public string Password { get; set; } = "";

//        public RoleType Role { get; set; }


//        public User(int userId, string name, string email, string password, RoleType role)
//        {
//            UserId = userId;
//            Name = name;
//            Email = email;
//            Password = password;
//            Role = role;
//        }

//        public User() { }
//    }
//}






//////////////////////////////////DB//////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////DB///////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////DB/////////////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Zealand_lokale_booking.Models;

public class User

{

    [Key]

    public int UserId { get; set; }


    [Required]

    public string Name { get; set; } = "";


    [Required]

    [EmailAddress]

    public string Email { get; set; } = "";


    [Required]

    public string Password { get; set; } = "";


    [Required]

    public int RoleId { get; set; }


    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
    public string? ImagePath { get; set; }

    // Navigation property

    public ICollection<UserCourse> UserCourses { get; set; }

        = new List<UserCourse>();



    public User() { }


    public User(string name, string email, string password, int roleId, string?  imagePath)

    {

        Name = name;

        Email = email;

        Password = password;

        RoleId = roleId;
        ImagePath = imagePath;
    }
}




