using Application.Common.Interfaces.Persistence;
using Application.Roles.Common;
using Domain.Common.Error;
using ErrorOr;
using MediatR;

namespace Application.Roles.Queries;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, ErrorOr<List<RoleResult>>>
{
    private readonly IRoleRepository _roleRepositoty;
    public GetRolesQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepositoty = roleRepository;
    }

    public async Task<ErrorOr<List<RoleResult>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var roles = _roleRepositoty.GetRoles();

        List<RoleResult> rolesResult = new();
        foreach (var role in roles)
        {
            var roleResult = new RoleResult(role.Id, role.Name, role.IsAdmin, role.IsActive);
            rolesResult.Add(roleResult);
        }
        return rolesResult;


    }

}