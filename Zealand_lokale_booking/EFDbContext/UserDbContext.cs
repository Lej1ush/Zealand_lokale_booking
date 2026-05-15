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

        public DbSet<Booking> Bookings { get; set; }
        
        public DbSet<BookingPart> BookingParts { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<SmartBoard> SmartBoards { get; set; }

        public DbSet<TimeSlot> TimeSlots { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<UserCourse> UserCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Student" },
                new Role { RoleId = 3, RoleName = "Teacher" }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    Password = "admin123",
                    RoleId = 1
                }
            );

            modelBuilder.Entity<Building>().HasData(
                new Building
                {
                    BuildingId = 1,
                    BuildingName = "Building A",
                    Address = "Zealand Roskilde"
                }
            );

            modelBuilder.Entity<RoomType>().HasData(
                new RoomType
                {
                    RoomTypeId = 1,
                    TypeName = "Classroom"
                }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    RoomId = 1,
                    RoomName = "A101",
                    Capacity = 30,
                    BuildingId = 1,
                    RoomTypeId = 1
                }
            );
        }
    }
}


