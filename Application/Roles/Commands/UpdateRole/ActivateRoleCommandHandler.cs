using Application.Common.Interfaces.Persistence;
using Application.Roles.Common;
using Domain.Common.Error;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Roles.Commands.UpdateRole;

internal class ActivateRoleCommandHandler : IRequestHandler<ActivateDeactivateRoleCommand, ErrorOr<RoleResult>>
{
    private readonly IRoleRepository _roleRepository;

    public ActivateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<RoleResult>> Handle(ActivateDeactivateRoleCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_roleRepository.GetRoleById(command.RoleId) is null)
        {
            return Errors.Role.RoleNotFound;
        }

        var role = _roleRepository.ActivateDeactivateRole(command.RoleId, command.Flag);

        return new RoleResult(role.Id, role.Name, role.IsAdmin, role.IsActive);
    }
}
