using Application.Roles.Common;
using ErrorOr;
using MediatR;
namespace Application.Roles.Commands.UpdateRole;

public record ActivateDeactivateRoleCommand(Guid RoleId, bool Flag) : IRequest<ErrorOr<RoleResult>>;