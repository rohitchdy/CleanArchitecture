namespace Application.Roles.Common;
public record RoleResult(
    Guid Id,
    string Name,
    bool IsAdmin,
    bool IsActive
);
