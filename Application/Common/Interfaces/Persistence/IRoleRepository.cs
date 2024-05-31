using Domain.Entities;
namespace Application.Common.Interfaces.Persistence;
public interface IRoleRepository
{
    Role? GetRoleByName(string name);
    void AddRole(Role role);
    Role? GetRoleById(Guid roleId);
    List<Role> GetRoles();
    Role? UpdateRole(Role role);
    Role? ActivateDeactivateRole(Guid roleId, bool flag);
}
