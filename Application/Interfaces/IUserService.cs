using Application.DTOs;
using Shared;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Result> GetAllAsync();
        Task<Result> GetByIdAsync(Guid id);
        Task<Result> AddAsync(UserDto userDto);
        Task<Result> UpdateAsync(UserDto userDto);
        Task<Result> DeleteAsync(Guid id);
    }
}
