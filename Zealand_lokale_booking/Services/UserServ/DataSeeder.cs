//using Microsoft.AspNetCore.Identity;
//using Zealand_lokale_booking.EFDbContext;
//using Zealand_lokale_booking.Models;
//using Zealand_lokale_booking.Services.UserServ;

//namespace Zealand_lokale_booking.Services
//{
//    public class DataSeeder
//    {
//        private readonly UserDbContext _db;
//        private readonly JsonFileService _json;

//        public DataSeeder(UserDbContext db, JsonFileService json)
//        {
//            _db = db;
//            _json = json;
//        }

//        public void Seed()
//        {
//            if (_db.Users.Any())
//                return; // mos fus 2 here

//            var usersFromJson = _json.GetAll();

//            var hasher = new PasswordHasher<string>();

//            foreach (var user in usersFromJson)
//            {
//                user.Password = hasher.HashPassword(null, user.Password);
//                _db.Users.Add(user);
//            }

//            _db.SaveChanges();
//        }
//    }
//}