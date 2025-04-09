using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        return users.Select(u => new UserDto { Id = u.Id, FullName = u.FullName, Email = u.Email });
    }

    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null) return null;

        return new UserDto { Id = user.Id, FullName = user.FullName, Email = user.Email };
    }

    public async Task AddAsync(UserDto userDto)
    {
        var user = new User { Id = Guid.NewGuid(), FullName = userDto.FullName, Email = userDto.Email };
        await _repository.AddAsync(user);
    }

    public async Task UpdateAsync(UserDto userDto)
    {
        var user = new User { Id = userDto.Id, FullName = userDto.FullName, Email = userDto.Email };
        await _repository.UpdateAsync(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
