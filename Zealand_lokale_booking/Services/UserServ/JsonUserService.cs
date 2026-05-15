using Microsoft.AspNetCore.Identity;
using Zealand_lokale_booking.MockData;
using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Services.UserServ
{
    public class JsonUserService
    {

        private readonly JsonFileService _json;

        public JsonUserService(JsonFileService json)
        {
            _json = json;

            var users = _json.GetAll();                 // hash fra mock i json

            if (!users.Any())                              
            {
                var mockUsers = UserMock.GetUsers();
                _json.SaveAll(mockUsers);
            }           
        }

        public List<User> GetAllUsers()
        {
            return _json.GetAll();                                // GetAll(): Method from JsonFileService 
        }

        public List<User> GetUsersByRole(int roleId)
        {
            return _json.GetAll()
                .Where(u => u.RoleId == roleId)
                .ToList();
        }

        public User Login(string email, string password)
        {
            var user = _json.GetAll()
                .FirstOrDefault(u => u.Email == email);

            if (user == null)
                return null;

            var passwordHasher = new PasswordHasher<string>();

            var result = passwordHasher.VerifyHashedPassword(
                null,
                user.Password,
                password
            );

            if (result == PasswordVerificationResult.Success)
                return user;

            return null;
        }

        public void CreateUser(User user)
        {
            var users = _json.GetAll();

            var passwordHasher = new PasswordHasher<string>();
            user.Password = passwordHasher.HashPassword(null, user.Password);

            user.UserId = users.Any()
                ? users.Max(u => u.UserId) + 1
                : 1;

            users.Add(user);

            _json.SaveAll(users);
        }                                                                    // SaveAll(): Method from JsonFileService
        



        public void UpdateUser(User user)
        {
            var users = _json.GetAll();

            var existing = users.FirstOrDefault(u => u.UserId == user.UserId);

            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Email = user.Email;


                if (!string.IsNullOrWhiteSpace(user.Password))
                {
                    var passwordHasher = new PasswordHasher<string>();
                    existing.Password = passwordHasher.HashPassword(null, user.Password);
                }
                existing.RoleId = user.RoleId;
            }

            _json.SaveAll(users);
        }

        public void DeleteUser(int id)
        {
            var users = _json.GetAll();

            var user = users.FirstOrDefault(u => u.UserId == id);

            if (user != null)
                users.Remove(user);

            _json.SaveAll(users);
        }
    }
}

