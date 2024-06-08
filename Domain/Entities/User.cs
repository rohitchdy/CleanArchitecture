using Microsoft.AspNetCore.Identity;
namespace Domain.Entities;

public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public required List<UserRoles> UserRoles { get; set; }
    public required Parent Parent { get; set; }
    public required Employee Employee { get; set; }
}
