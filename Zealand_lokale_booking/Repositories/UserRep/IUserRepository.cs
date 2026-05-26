//using Zealand_lokale_booking.Models;

//namespace Zealand_lokale_booking.Repositories.UserRep
//{
//    public interface IUserRepository
//    {
//        void Save();

//        List<User> GetAll();

//        User? GetById(int id);

//        User? GetByEmail(string email);

//        void Add(User user);

//        void Update(User user);

//        void Delete(int id);

//        List<User> GetByRole(int roleId);
//    }
//}




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
        Task<List<User>> GetByRoleAsync(int roleId);
        Task<List<User>> GetUsersWithRolesAsync();
    }
}
