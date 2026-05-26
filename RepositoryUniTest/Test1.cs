using Moq;
using Xunit;
using Assert = Xunit.Assert;
using Zealand_lokale_booking.Models;
using Zealand_lokale_booking.Repositories.UserRep;
using Zealand_lokale_booking.Services.UserServ;

namespace RepositoryUniTest
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepo;

        private readonly JsonUserService _service;

        public UserServiceTests()
        {
            _mockRepo = new Mock<IUserRepository>();

            _service = new JsonUserService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllUsersAsync_ReturnsUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    Password = "1234",
                    RoleId = 1
                }
            };

            _mockRepo
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(users);

            // Act
            var result = await _service.GetAllUsersAsync();

            // Assert
            Assert.Single(result);

            Assert.Equal("Admin", result[0].Name);
        }

        [Fact]
        public async Task GetByRoleAsync_ReturnsCorrectUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    Name = "Admin",
                    RoleId = 1
                }
            };

            _mockRepo
                .Setup(r => r.GetByRoleAsync(1))
                .ReturnsAsync(users);

            // Act
            var result = await _service.GetUsersByRoleAsync(1);

            // Assert
            Assert.Single(result);

            Assert.Equal(1, result[0].RoleId);
        }

        [Fact]
        public async Task CreateUserAsync_AddsUser()
        {
            // Arrange
            var user = new User
            {
                Name = "John",
                Email = "john@gmail.com",
                Password = "1234",
                RoleId = 2
            };

            _mockRepo
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<User>());

            // Act
            await _service.CreateUserAsync(user);

            // Assert
            _mockRepo.Verify(
                r => r.AddAsync(It.IsAny<User>()),
                Times.Once);

            _mockRepo.Verify(
                r => r.SaveAsync(),
                Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_DeletesUser()
        {
            // Act
            await _service.DeleteUserAsync(1);

            // Assert
            _mockRepo.Verify(
                r => r.DeleteAsync(1),
                Times.Once);

            _mockRepo.Verify(
                r => r.SaveAsync(),
                Times.Once);
        }
    }
}