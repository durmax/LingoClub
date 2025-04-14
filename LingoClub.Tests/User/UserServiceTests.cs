using Application.Interfaces;
using Application.Services;
using Moq;
using FluentAssertions;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;
using Newtonsoft.Json.Linq;
using Shared;

namespace LingoClub.Tests.User
{
    public class UserServiceTests
    {
        private readonly Mock<IAppDbContext> _context;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _context = new Mock<IAppDbContext>();
            _userService = new UserService(_context.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var userId = Guid.Parse("1ef571ba-4263-45e1-972f-fc5bed01cb37");
            var expectedUser = new Domain.Users.User { Id = userId, FullName = "John Doe" };
            _context.Setup(r => r.Users.FindAsync(userId)).ReturnsAsync(expectedUser);

            // Act
            Result<UserDto> result = await _userService.GetByIdAsync(userId);

            // Assert
            result.Value.Should().BeEquivalentTo(expectedUser);
        }

        //[Fact]
        //public async Task GetAllAsync_ReturnsUsers_WhenUsersExist()
        //{
        //    // Arrange
        //    var users = new List<Domain.Users.User>
        //{
        //    new Domain.Users.User { Id = Guid.Parse("1ef571ba-4263-45e1-972f-fc5bed01cb37"), FullName = "John Doe" },
        //    new Domain.Users.User { Id = Guid.Parse("2ef571ba-4263-45e1-972f-fc5bed01cb37"), FullName = "Jane Smith" }
        //}.AsQueryable();

        //    var mockSet = new Mock<DbSet<Domain.Users.User>>();
        //    mockSet.As<IQueryable<Domain.Users.User>>().Setup(m => m.Provider).Returns(users.Provider);
        //    mockSet.As<IQueryable<Domain.Users.User>>().Setup(m => m.Expression).Returns(users.Expression);
        //    mockSet.As<IQueryable<Domain.Users.User>>().Setup(m => m.ElementType).Returns(users.ElementType);
        //    mockSet.As<IQueryable<Domain.Users.User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());
        //    mockSet.As<IAsyncEnumerable<Domain.Users.User>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
        //        .Returns(new TestAsyncEnumerator<Domain.Users.User>(users.GetEnumerator()));

        //    _context.Setup(c => c.Users).Returns(mockSet.Object);

        //    // Act
        //    var result = await _userService.GetAllAsync();

        //    // Assert
        //    result.Should().BeEquivalentTo(users);
        //}
    }

}
