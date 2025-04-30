using Application.DTOs;
using Shared;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserDto>>> GetAllAsync();
        Task<Result<UserDto>> GetAsync(Guid id);
        Task<Result<UserDto>> GetAsync(string email);
        Task<Result<List<UserDto>>> GetByNameAsync(string name);
        Task<Result> AddAsync(UserDto userDto);
        Task<Result> UpdateAsync(UserDto userDto);
        Task<Result> DeleteAsync(UserDto userDto);
    }
}
