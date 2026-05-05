using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Repositories.UserRep
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);

        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);

        Task SaveAsync();
        Task<List<User>> GetByRoleAsync(RoleType role);
    }
}
