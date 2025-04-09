using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new() {
        new User {
            Id= Guid.Parse("1ef571ba-4263-45e1-972f-fc5bed01cb37"),
            Email="test1@test.test",
            FullName="test1",
        },
        new User {
            Id= Guid.Parse("2ef571ba-4263-45e1-972f-fc5bed01cb37"),
            Email="test2@test.test",
            FullName="test2",
        },
        new User {
            Id= Guid.Parse("3ef571ba-4263-45e1-972f-fc5bed01cb37"),
            Email="test3@test.test",
            FullName="test3",
        },
        new User {
            Id= Guid.Parse("4ef571ba-4263-45e1-972f-fc5bed01cb37"),
            Email="test4@test.test",
            FullName="test4",
        },
        new User {
            Id= Guid.Parse("5ef571ba-4263-45e1-972f-fc5bed01cb37"),
            Email="test5@test.test",
            FullName="test5",
        }
    };

    public Task<IEnumerable<User>> GetAllAsync() => Task.FromResult(_users.AsEnumerable());

    public Task<User?> GetByIdAsync(Guid id) => Task.FromResult(_users.FirstOrDefault(u => u.Id == id));

    public Task AddAsync(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(User user)
    {
        var existing = _users.FirstOrDefault(u => u.Id == user.Id);
        if (existing != null)
        {
            existing.FullName = user.FullName;
            existing.Email = user.Email;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        _users.RemoveAll(u => u.Id == id);
        return Task.CompletedTask;
    }
}
