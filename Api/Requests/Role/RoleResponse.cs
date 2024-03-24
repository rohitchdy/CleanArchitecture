namespace Api.Requests.Role;
public record RoleResponse(
    Guid Id,
    string Name,
    bool IsAdmin,
    bool IsActive
);
