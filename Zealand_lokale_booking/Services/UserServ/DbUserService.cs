//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Zealand_lokale_booking.Models;
//using Zealand_lokale_booking.Repositories.UserRep;

//namespace Zealand_lokale_booking.Services.UserServ
//{
//    public class DbUserService : IUserService
//    {
        

//        private readonly IUserRepository _repo;
//        //private readonly JsonFileService _json;

//        public DbUserService(IUserRepository repo/*, JsonFileService json*/)
//        {
//            _repo = repo;
//            //_json = json;
//        }


//        //public async Task SeedFromJsonAsync()
//        //{
//        //    var usersInDb = await _repo.GetAllAsync();

//        //    if (!usersInDb.Any())
//        //    {
//        //        var jsonUsers = _json.GetAll();

//        //        foreach (var u in jsonUsers)
//        //        {
//        //            await _repo.AddAsync(u);
//        //        }

//        //        await _repo.SaveAsync();
//        //    }
//        //}

//        //  Get all users
//        public async Task<List<User>> GetAllUsersAsync()
//        {
//            return await _repo.GetAllAsync();
//        }

//        //  Get users by role
//        public async Task<List<User>> GetUsersByRoleAsync(int roleId)
//        {
//            return await _repo.GetByRoleAsync(roleId);
//        }
//        //  Login
//        public async Task<User?> LoginAsync(string email, string password)
//        {
//            var user = await _repo.GetByEmailAsync(email);

//            if (user == null)
//                return null;

//            if (user.Password == password)
//                return user;

//            return null;
//        }
//        //  Create user 
//        public async Task CreateUserAsync(User user)
//        {
//            await _repo.AddAsync(user);
//            await _repo.SaveAsync();
//        }

//        // Delete user
//        public async Task DeleteUserAsync(int id)
//        {
//            await _repo.DeleteAsync(id);
//            await _repo.SaveAsync();
//        }

//        //  Update user
//        public async Task UpdateUserAsync(User user)
//        {
//            await _repo.UpdateAsync(user);
//            await _repo.SaveAsync();
//        }
//    }
//}

