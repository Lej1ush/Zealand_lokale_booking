//using Zealand_lokale_booking.Models;

//namespace Zealand_lokale_booking.Services.UserServ
//{
//    public interface IUserService
//    {
//        List<User> GetAllUsers();

//        User? Login(string email, string password);

//        List<User> GetUsersByRole(int roleId);

//        void AddUser(User user);

//        void CreateUser(User user);

//        void UpdateUser(User user);

//        void DeleteUser(int id);
//    }
//}




using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Services.UserServ
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();

        Task<User?> LoginAsync(string email, string password);

        Task<List<User>> GetUsersByRoleAsync(int roleId);

        Task<List<User>> GetUsersWithRolesAsync();

        Task CreateUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int id);
    }
}