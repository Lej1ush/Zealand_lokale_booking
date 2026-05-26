//using Zealand_lokale_booking.EFDbContext;
//using Zealand_lokale_booking.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Zealand_lokale_booking.Repositories.UserRep
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly UserDbContext _context;

//        public UserRepository(UserDbContext context)
//        {
//            _context = context;
//        }

//        // Save changes
//        public void Save()
//        {
//            _context.SaveChanges();
//        }

//        // Get all users
//        public List<User> GetAll()
//        {
//            return _context.Users.ToList();
//        }

//        // Get user by Id
//        public User? GetById(int id)
//        {
//            return _context.Users
//                .FirstOrDefault(u => u.UserId == id);
//        }

//        // Get user by Email
//        public User? GetByEmail(string email)
//        {
//            return _context.Users
//                .FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
//        }

//        // Add new user
//        public void Add(User user)
//        {
//            _context.Users.Add(user);
//        }

//        // Update user
//        public void Update(User user)
//        {
//            _context.Users.Update(user);
//        }

//        // Delete user
//        public void Delete(int id)
//        {
//            var user = _context.Users.Find(id);

//            if (user != null)
//            {
//                _context.Users.Remove(user);
//            }
//        }

//        // Get users by role
//        public List<User> GetByRole(int roleId)
//        {
//            return _context.Users
//                .Where(u => u.RoleId == roleId)
//                .ToList();
//        }
//    }
//}


using Zealand_lokale_booking.EFDbContext;
using Zealand_lokale_booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Zealand_lokale_booking.Repositories.UserRep
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        //DB  
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        //  Get all users
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        //  Get user by Id
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        //  Get user by Email
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        //  Add new user
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        //  Update user
        public Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            return Task.CompletedTask;
        }
        //  Delete user

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public async Task<List<User>> GetByRoleAsync(int roleId)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Where(u => u.RoleId == roleId)
                .ToListAsync();
        }
        public async Task<List<User>> GetUsersWithRolesAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .ToListAsync();
        }
    }
}





