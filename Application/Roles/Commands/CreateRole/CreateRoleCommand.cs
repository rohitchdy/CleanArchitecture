using Application.Roles.Common;
using ErrorOr;
using MediatR;
namespace Application.Roles.Commands.CreateRole;

public record CreateRoleCommand(string Name) : IRequest<ErrorOr<RoleResult>>;