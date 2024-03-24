using Application.Common.Interfaces.Persistence;
using Application.Roles.Common;
using Application.Authentication.Common;
using Domain.Common.Error;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Roles.Commands.CreateRole;
public class CreateCommandHandler : IRequestHandler<CreateRoleCommand, ErrorOr<RoleResult>>
{
    private readonly IRoleRepository _roleRepository;

    public CreateCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<RoleResult>> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_roleRepository.GetRoleByName(command.Name) is not null)
        {
            return Errors.Role.DuplicateRole;
        }

        var role = new Role
        {
            Name = command.Name,
            IsActive = true
        };
        _roleRepository.AddRole(role);

        return new RoleResult(role.Id, role.Name, role.IsAdmin, role.IsActive);
    }
}
