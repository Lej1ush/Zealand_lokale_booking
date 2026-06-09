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

            modelBuilder.Entity<SmartBoard>()
                .HasOne(s => s.Room)
                .WithMany()
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Student" },
                new Role { RoleId = 3, RoleName = "Teacher" }
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
                },
                new Room
                {
                    RoomId = 2,
                    RoomName = "A102",
                    Capacity = 25,
                    BuildingId = 1,
                    RoomTypeId = 1
                },
                new Room
                {
                    RoomId = 3,
                    RoomName = "B201",
                    Capacity = 80,
                    BuildingId = 1,
                    RoomTypeId = 1
                }
            );

            modelBuilder.Entity<SmartBoard>().HasData(
                new SmartBoard
                {
                    SmartBoardId = 1,
                    SmartBoardName = "SmartBoard 65\" Samsung",
                    SizeInches = 65,
                    Description = "Interaktiv touchskærm til undervisning, gruppearbejde og mindre præsentationer.",
                    Availability = true,
                    RoomId = 1
                },
                new SmartBoard
                {
                    SmartBoardId = 2,
                    SmartBoardName = "SmartBoard 75\" Promethean",
                    SizeInches = 75,
                    Description = "Digital tavle til præsentationer, noter og almindelig klasseundervisning.",
                    Availability = true,
                    RoomId = 2
                },
                new SmartBoard
                {
                    SmartBoardId = 3,
                    SmartBoardName = "SmartBoard 86\" ViewSonic",
                    SizeInches = 86,
                    Description = "Stor interaktiv skærm velegnet til auditorier, forelæsninger og større hold.",
                    Availability = true,
                    RoomId = 3
                }
            );
        }
    }
}

