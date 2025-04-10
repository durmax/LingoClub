using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Moq;
using FluentAssertions;

namespace LingoClub.Tests.User
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var userId = Guid.Parse("1ef571ba-4263-45e1-972f-fc5bed01cb37");
            var expectedUser = new Domain.Entities.User { Id = userId, FullName = "John Doe" };
            _userRepositoryMock.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(expectedUser);

            // Act
            var result = await _userService.GetByIdAsync(userId);

            // Assert
            result.Should().BeEquivalentTo(expectedUser);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsUsers_WhenUsersExist()
        {
            // Arrange
            var users = new List<Domain.Entities.User>
        {
            new Domain.Entities.User { Id = Guid.Parse("1ef571ba-4263-45e1-972f-fc5bed01cb37"), FullName = "John Doe" },
            new Domain.Entities.User { Id = Guid.Parse("2ef571ba-4263-45e1-972f-fc5bed01cb37"), FullName = "Jane Smith" }
        };
            _userRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _userService.GetAllAsync();

            // Assert
            result.Should().BeEquivalentTo(users);
        }
    }

}
