using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Services.UserServ
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User Login(string email, string password);
        List<User> GetUsersByRole(RoleType role);

        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
