using Application.Common.Interfaces.Persistence;
using Application.Roles.Common;
using Application.Authentication.Common;
using Domain.Common.Error;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Roles.Commands.UpdateRole;
public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, ErrorOr<RoleResult>>
{
    private readonly IRoleRepository _roleRepository;

    public UpdateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<RoleResult>> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var existingRole = _roleRepository.GetRoleById(command.RoleId);

        if (existingRole is null)
        {
            return Errors.Role.RoleNotFound;
        }

        existingRole.Name = command.Name;
        _roleRepository.UpdateRole(existingRole);

        return new RoleResult(existingRole.Id, existingRole.Name, existingRole.IsAdmin, existingRole.IsActive);
    }
}
