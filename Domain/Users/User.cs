using System.Data;

namespace Domain.Users;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string Email { get; set; } = default!;
    public Role Role { get; set; }
}

public enum Role
{
    Owner = 0,
    Admin = 1,
    User = 3,
}