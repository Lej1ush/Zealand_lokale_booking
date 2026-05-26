using Zealand_lokale_booking.Models;
namespace Zealand_lokale_booking.MockData;
//private static List<User> _users = new List<User>
//{
//    new User(1, "Sona", "sad004@edu.zealand.dk", "1234", RoleType.Student),
//    new User(2, "John", "john@zealand.dk", "1234", RoleType.Teacher),
//    new User(3, "Admin", "admin@gmail.com", "admin", RoleType.Admin)
//};
        public class UserMock
        {
            public static List<User> GetUsers()
            {
                return new List<User>
                {
                    new User //studerende
                    {
                        UserId = 1, 
                        Name = "Sona",
                        Email = "sad004@edu.zealand.dk",
                        Password = "1234",
                        RoleId = 1
                    },

                    new User //medarbejder
                    {
                        UserId = 2,
                        Name = "John",
                        Email = "john@zealand.dk",
                        Password = "1234",
                        RoleId = 2
                    },

                    new User //admin
                    {
                        UserId = 3,
                        Name = "Admin",
                        Email = "admin@gmail.com",
                        Password = "admin123",
                        RoleId = 3
                    }
                };
            }
        }

    

