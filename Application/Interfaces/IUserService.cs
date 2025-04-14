using Application.DTOs;
using Domain.Users;
using Shared;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserDto>>> GetAllAsync();
        Task<Result<UserDto>> GetByIdAsync(Guid id);
        Task<Result> AddAsync(UserDto userDto);
        Task<Result> UpdateAsync(UserDto userDto);
        Task<Result> DeleteAsync(UserDto userDto);
    }
}
