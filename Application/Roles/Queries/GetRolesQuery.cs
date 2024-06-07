
using Application.Roles.Common;
using ErrorOr;
using MediatR;

namespace Application.Roles.Queries;

public record GetRolesQuery() : IRequest<ErrorOr<List<RoleResult>>>;
