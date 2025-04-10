using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using SharedKernel;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<UserDto>>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        var dtos= users.Select(u => new UserDto { Id = u.Id, FullName = u.FullName, Email = u.Email });
        return Result.Success(dtos);
    }

    public async Task<Result<UserDto?>> GetByIdAsync(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null) return null;

        var dto = new UserDto { Id = user.Id, FullName = user.FullName, Email = user.Email };
        return Result.Success(dto);
    }

    public async Task<Result> AddAsync(UserDto userDto)
    {
        var user = new User { Id = Guid.NewGuid(), FullName = userDto.FullName, Email = userDto.Email };
        await _repository.AddAsync(user);
        return Result.Success();
    }

    public async Task<Result> UpdateAsync(UserDto userDto)
    {
        var user = new User { Id = userDto.Id, FullName = userDto.FullName, Email = userDto.Email };
        await _repository.UpdateAsync(user);
        return Result.Success();
    }

    public async Task<Result> DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
        return Result.Success();
    }
}
