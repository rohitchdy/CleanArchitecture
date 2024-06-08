namespace Application.Roles.Common;
public record RoleResult(
    Guid RoleId,
    string Name,
    bool IsAdmin,
    bool IsActive
);
