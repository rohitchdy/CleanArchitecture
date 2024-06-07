using FluentValidation;

namespace Application.Roles.Queries;

public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
{
    public GetRoleByIdQueryValidator()
    {
        RuleFor(r => r.roleId).NotEmpty();
    }
}
