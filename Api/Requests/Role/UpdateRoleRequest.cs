namespace Api.Requests.Role;

public class UpdateRoleRequest
{
    public Guid RoleId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
