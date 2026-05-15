using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Services.UserServ
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();

        Task<User?> LoginAsync(string email, string password);

        Task<List<User>> GetUsersByRoleAsync(int roleId);

        Task CreateUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int id);
    }
}