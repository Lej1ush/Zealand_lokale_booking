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
                .Where(u => u.RoleId == roleId)
                .ToListAsync();
        }
    }
}





