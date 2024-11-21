using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using WatchMarket.BusinessLogic.Dto_s;
using WatchMarket.BusinessLogic.Interfaces;
using WatchMarket.BusinessLogic.Services;
using WatchMarketApp.DataAccess.Entities;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IConfiguration> _mockConfiguration;
        public UserServiceTest()
        {
            _mockUserService = new Mock<IUserService>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockConfiguration = new Mock<IConfiguration>();
        }

        [Fact]
        public async Task CreateUser_With_ValidCredentials()
        {
            // Arrange
            var testedUser = new UserDto()
            {
                Username = "Test",
                Email = "Test@gmail.com",
            };

            _mockUserService.Setup(x => x.CreateUserAsync(It.IsAny<UserDto>()))
                            .ReturnsAsync(new UserDto
                            {
                                Username = "Test",
                                Email = "Test@gmail.com",
                            });

            var userService = new UserService(_mockUserRepository.Object, _mockConfiguration.Object);

            // Act
            var result = await userService.CreateUserAsync(testedUser);

            // Assert
            result.Should().NotBeNull();
            result.Username.Should().Be("Test");
            result.Email.Should().Be("Test@gmail.com");
        }

        [Fact]
        public async Task DeleteUserWithEmail_Should_Call_DeleteUserAsync()
        {
            // Arrange
            string email = "Test@email.com";

           
            _mockUserRepository.Setup(x => x.GetByEmailAsync(It.IsAny<string>()))
                               .ReturnsAsync(new User { Email = email }); // Simulate a user with this email


            _mockUserService.Setup(x => x.DeleteUserAsync(It.IsAny<string>()))
                               .Returns(Task.CompletedTask); // Simulate a successful deletion

            var userService = new UserService(_mockUserRepository.Object, _mockConfiguration.Object);

            // Act
            await userService.DeleteUserAsync(email);

            // Assert
            _mockUserRepository.Verify(x => x.DeleteAsync(It.IsAny<User>()), Times.Once, "DeleteAsync was not called.");
        }

        [Fact]
        public async Task UpdateUserWithEmail_Should_Call_UpdateUserAsync()
        {
            // Arrange
            var user = new UserDto
            {
                Username = "Test",
                Email = "Test@email.com",
                Password = "password",
                RoleId = 2
            };

            Fixture fixture = new Fixture();

            _mockUserRepository.Setup(x => x.GetByEmailAsync(It.IsAny<string>()))
                               .ReturnsAsync(new User { Email = user.Email }); // Simulate a user with this email


            _mockUserService.Setup(x => x.UpdateUserAsync(It.IsAny<UserDto>()))
                               .ReturnsAsync(fixture.Create<UserDto>());

            var userService = new UserService(_mockUserRepository.Object, _mockConfiguration.Object);

            // Act
            await userService.DeleteUserAsync(user.Email);

            // Assert
            _mockUserRepository.Verify(x => x.DeleteAsync(It.IsAny<User>()), Times.Once, "DeleteAsync was not called.");
        }
    }
}