namespace Domain.Entities;
public class Role
{
    public Guid RoleId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public bool IsAdmin { get; set; }
    public bool IsActive { get; set; }
    public required List<UserRoles> UserRoles { get; set; }
}
