using Api.Requests.Role;
using Application.Roles.Commands.CreateRole;
using Application.Roles.Common;
using Application.Roles.Queries;
using Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class RoleController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public RoleController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("Role")]
        public async Task<IActionResult> AddRole(CreateRoleRequest roleRequest)
        {
            await Task.CompletedTask;
            var command = _mapper.Map<CreateRoleCommand>(roleRequest);
            ErrorOr<RoleResult> roleResponse = await _mediator.Send(command);
            return roleResponse.Match(
                roleResult => Ok(_mapper.Map<RoleResponse>(roleResult)),
                errors => Problem(errors)
                );
        }

        [HttpGet]
        [Route("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            await Task.CompletedTask;
            var query = new GetRolesQuery();

            ErrorOr<List<RoleResult>> roleResponse = await _mediator.Send(query);
            return roleResponse.Match(
                roleResult => Ok(_mapper.Map<List<RoleResponse>>(roleResult)),
                errors => Problem(errors)
                );
        }

        [HttpGet]
        [Route("Role")]
        public async Task<IActionResult> GetRole(Guid roleId)
        {
            await Task.CompletedTask;
            var query = _mapper.Map<GetRoleByIdQuery>(roleId);
            ErrorOr<RoleResult> roleResponse = await _mediator.Send(query);
            return roleResponse.Match(
                roleResult => Ok(_mapper.Map<RoleResponse>(roleResult)),
                errors => Problem(errors)
                );
        }
    }
}
