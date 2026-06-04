using Microsoft.AspNetCore.Identity;
using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.MockData
{
    public class UserMock
    {
        // Roles
        private static Role adminRole = new Role(1, "Admin");
        private static Role studentRole = new Role(2, "Student");
        private static Role teacherRole = new Role(3, "Teacher");
   
        private static PasswordHasher<string> passwordHasher =
            new PasswordHasher<string>();

        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserId = 1,
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    Password = passwordHasher.HashPassword(null, "admin123"),
                    RoleId = 1
                },

                new User
                {
                    UserId = 2,
                    Name = "John",
                    Email = "john@zealand.dk",
                    Password = passwordHasher.HashPassword(null, "1234"),
                    RoleId = 3
                },

                new User
                {
                    UserId = 3,
                    Name = "Sona",
                    Email = "sad004@edu.zealand.dk",
                    Password = passwordHasher.HashPassword(null, "1234"),
                    RoleId = 2
                }
            };
        }
    }
}