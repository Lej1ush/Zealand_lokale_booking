using Microsoft.AspNetCore.Identity;
using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.MockData
{
    public class UserMock
    {
        //private static List<User> _users = new List<User>
        //{
        //    new User(1, "Sona", "sad004@edu.zealand.dk", "1234", RoleType.Student),
        //    new User(2, "John", "john@zealand.dk", "1234", RoleType.Teacher),
        //    new User(3, "Admin", "admin@gmail.com", "admin", RoleType.Admin)
        //};





       private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        private static List<User> _users = new List<User>
        {
            new User(1, "Sona", "sad004@edu.zealand.dk",
                passwordHasher.HashPassword(null, "1234"), RoleType.Student),

            new User(2, "John", "john@zealand.dk",
                passwordHasher.HashPassword(null, "1234"), RoleType.Teacher),

            new User(3, "Admin", "admin@gmail.com",
                passwordHasher.HashPassword(null, "admin"), RoleType.Admin)
        };


        public static List<User> GetMockUsers()
        {
            return _users;
        }
    }
}

    

