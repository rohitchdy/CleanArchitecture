
using Application.Roles.Common;
using ErrorOr;
using MediatR;

namespace Application.Roles.Queries;

public record GetRoleByIdQuery(Guid roleId) : IRequest<ErrorOr<RoleResult>>;
