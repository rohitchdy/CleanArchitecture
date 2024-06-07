using Application.Common.Interfaces.Persistence;
using Application.Roles.Common;
using Domain.Common.Error;
using ErrorOr;
using MediatR;

namespace Application.Roles.Queries;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, ErrorOr<RoleResult>>
{
    private readonly IRoleRepository _roleRepositoty;
    public GetRoleByIdQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepositoty = roleRepository;
    }
    public async Task<ErrorOr<RoleResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var role = _roleRepositoty.GetRoleById(request.roleId);
        if (role is null)
        {
            return Errors.Role.RoleNotFound;
        }
        var roleResult = new RoleResult(role.Id, role.Name, role.IsAdmin, role.IsActive);
        return roleResult;
    }
}
