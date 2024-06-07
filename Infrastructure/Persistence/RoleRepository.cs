using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class RoleRepository : IRoleRepository
{
    private readonly DataContext _dataContext;

    public RoleRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public void AddRole(Role role)
    {
        _dataContext.Roles.Add(role);
        _dataContext.SaveChanges();
    }

    public Role? GetRoleById(Guid roleId)
    {
        return _dataContext.Roles.SingleOrDefault(r => r.Id == roleId);
    }

    public Role? GetRoleByName(string name)
    {
        return _dataContext.Roles.SingleOrDefault(r => r.Name == name);
    }

    public List<Role> GetRoles()
    {
        return _dataContext.Roles.ToList();
    }

    public Role? UpdateRole(Role role)
    {
        _dataContext.Entry(role).State = EntityState.Modified;
        _dataContext.SaveChanges();
        return role;
    }

    public Role? ActivateDeactivateRole(Guid roleId, bool flag)
    {
        var role = _dataContext.Roles.FirstOrDefault(r => r.Id == roleId);
        if (role != null)
        {
            role.IsActive = flag;
            _dataContext.SaveChanges();
        }
        return role;
    }
}
