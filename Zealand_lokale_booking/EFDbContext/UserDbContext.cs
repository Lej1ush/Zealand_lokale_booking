using System.Collections.Generic;
using Zealand_lokale_booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Zealand_lokale_booking.EFDbContext
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}


