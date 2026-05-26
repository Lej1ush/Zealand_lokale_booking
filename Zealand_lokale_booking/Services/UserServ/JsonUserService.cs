//using Microsoft.AspNetCore.Identity;
//using Zealand_lokale_booking.MockData;
//using Zealand_lokale_booking.Models;
//using Zealand_lokale_booking.Repositories.UserRep;

//namespace Zealand_lokale_booking.Services.UserServ
//{
//    public class JsonUserService : IUserService
//    {

//        private List<User> _users;

//        private JsonFileService _json;

//        private UserRepository _userRepository;

//        public JsonUserService(JsonFileService jsonFileService, UserRepository userRepository)
//        {
//            _json =  jsonFileService;

//            _userRepository = userRepository;

//            //_users = UserMock.GetUsers();

//            _users = _json.GetAll().ToList();

//            _users = _userRepository.GetAll();
//        }

//        public void AddUser(User user)
//        {
//            _users.Add(user);

//            _json.SaveAll(_users);

//            _userRepository.Add(user);
//        }


//        public List<User> GetAllUsers()
//        {
//            return _json.GetAll();                                // GetAll(): Method from JsonFileService 
//        }

//        public List<User> GetUsersByRole(int roleId)
//        {
//            return _json.GetAll()
//                .Where(u => u.RoleId == roleId)
//                .ToList();
//        }

//        public User Login(string email, string password)
//        {
//            var user = _json.GetAll()
//                .FirstOrDefault(u => u.Email == email);

//            if (user == null)
//                return null;

//            var passwordHasher = new PasswordHasher<string>();

//            var result = passwordHasher.VerifyHashedPassword(
//                null,
//                user.Password,
//                password
//            );

//            if (result == PasswordVerificationResult.Success)
//                return user;

//            return null;
//        }

//        public void CreateUser(User user)
//        {
//            var users = _json.GetAll();

//            var passwordHasher = new PasswordHasher<string>();
//            user.Password = passwordHasher.HashPassword(null, user.Password);

//            user.UserId = users.Any()
//                ? users.Max(u => u.UserId) + 1
//                : 1;

//            users.Add(user);

//            _json.SaveAll(users);
//        }                                                                    // SaveAll(): Method from JsonFileService




//        public void UpdateUser(User user)
//        {
//            var users = _json.GetAll();

//            var existing = users.FirstOrDefault(u => u.UserId == user.UserId);

//            if (existing != null)
//            {
//                existing.Name = user.Name;
//                existing.Email = user.Email;


//                if (!string.IsNullOrWhiteSpace(user.Password))
//                {
//                    var passwordHasher = new PasswordHasher<string>();
//                    existing.Password = passwordHasher.HashPassword(null, user.Password);
//                }
//                existing.RoleId = user.RoleId;
//            }

//            _json.SaveAll(users);
//        }

//        public void DeleteUser(int id)
//        {
//            var users = _json.GetAll();

//            var user = users.FirstOrDefault(u => u.UserId == id);

//            if (user != null)
//                users.Remove(user);

//            _json.SaveAll(users);
//        }
//    }
//}




using Microsoft.AspNetCore.Identity;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Repositories.UserRep;

namespace Zealand_lokale_booking.Services.UserServ
{
    public class JsonUserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public JsonUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<List<User>> GetUsersByRoleAsync(int roleId)
        {
            return await _userRepository
                .GetByRoleAsync(roleId);
        }

        public async Task<List<User>> GetUsersWithRolesAsync()
        {
            return await _userRepository.GetUsersWithRolesAsync();
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _userRepository
                .GetByEmailAsync(email);

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

        public async Task CreateUserAsync(User user)
        {
            var users = await _userRepository
                .GetAllAsync();

            var passwordHasher = new PasswordHasher<string>();

            user.Password = passwordHasher
                .HashPassword(null, user.Password);

            user.UserId = users.Any()
                ? users.Max(u => u.UserId) + 1
                : 1;

            await _userRepository.AddAsync(user);

            await _userRepository.SaveAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var existing = await _userRepository
                .GetByIdAsync(user.UserId);

            if (existing != null)
            {
                existing.Name = user.Name;

                existing.Email = user.Email;

                existing.RoleId = user.RoleId;

                if (!string.IsNullOrWhiteSpace(user.Password))
                {
                    var passwordHasher = new PasswordHasher<string>();

                    existing.Password = passwordHasher
                        .HashPassword(null, user.Password);
                }

                await _userRepository.UpdateAsync(existing);

                await _userRepository.SaveAsync();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);

            await _userRepository.SaveAsync();
        }
    }
}