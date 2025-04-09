using Application.DTOs;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(Guid id);
        Task AddAsync(UserDto userDto);
        Task UpdateAsync(UserDto userDto);
        Task DeleteAsync(Guid id);
    }
}
