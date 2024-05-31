using FluentValidation;

namespace Application.Roles.Commands.CreateRole;
public class UpdateRoleValidator : AbstractValidator<CreateRoleCommand>
{
    public UpdateRoleValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
