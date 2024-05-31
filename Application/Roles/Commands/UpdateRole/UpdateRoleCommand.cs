using Application.Roles.Common;
using ErrorOr;
using MediatR;

namespace Application.Roles.Commands.UpdateRole;
public record UpdateRoleCommand(Guid RoleId,string Name) : IRequest<ErrorOr<RoleResult>>;
