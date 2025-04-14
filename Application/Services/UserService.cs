using Application.DTOs;
using Application.Interfaces;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Application.Services;

public class UserService(IAppDbContext context): IUserService
{

    public async Task<Result> GetAllAsync()
    {
        var users = await context.Users.ToListAsync();
        var dtos = users.Select(u => new UserDto { Id = u.Id, FullName = u.FullName, Email = u.Email }).ToList();
        return Result.Success(dtos);
    }

    public async Task<Result<UserDto>> GetByIdAsync(Guid id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return Result.Failure<UserDto>(UserErrors.NotFound(id));

        var dto = new UserDto { Id = user.Id, FullName = user.FullName, Email = user.Email };
        return Result.Success(dto);
    }

    public async Task<Result> AddAsync(UserDto userDto)
    {
        var user = new User { Id = Guid.NewGuid(), FullName = userDto.FullName, Email = userDto.Email };
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> UpdateAsync(UserDto userDto)
    {
        var user = new User { Id = userDto.Id, FullName = userDto.FullName, Email = userDto.Email };
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> DeleteAsync(UserDto userDto)
    {
        var user = new User { Id = userDto.Id, FullName = userDto.FullName, Email = userDto.Email };
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return Result.Success();
    }
}
