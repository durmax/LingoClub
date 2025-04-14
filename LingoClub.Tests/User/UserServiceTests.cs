using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using FluentAssertions;
using Infrastructure.Repositories;
using Shared;

namespace LingoClub.Tests.User
{
    public class UserServiceTests
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _context = TestDbContextFactory.Create();
            _context.Users.AddRange(
                new Domain.Users.User { Id = Guid.Parse("1ef571ba-4263-45e1-972f-fc5bed01cb37"), FullName = "John Doe", Email = "john@example.com" },
                new Domain.Users.User { Id = Guid.NewGuid(), FullName = "Jane Smith", Email = "jane@example.com" }
            );
            _context.SaveChanges();

            _userService = new UserService(_context);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllUsers()
        {
            // Act
            Result<IEnumerable<UserDto>> result = await _userService.GetAllAsync();

            // Assert
            result.IsSuccess.Should().BeTrue();
            var users = result.Value as List<UserDto>;
            users.Should().HaveCount(2);
            users.Should().Contain(u => u.FullName == "John Doe");
            users.Should().Contain(u => u.FullName == "Jane Smith");
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var userId = Guid.Parse("1ef571ba-4263-45e1-972f-fc5bed01cb37");

            // Act
            Result<UserDto> result = await _userService.GetByIdAsync(userId);

            // Assert
            result.Value.FullName.Should().BeEquivalentTo("John Doe");
        }
    }

}
