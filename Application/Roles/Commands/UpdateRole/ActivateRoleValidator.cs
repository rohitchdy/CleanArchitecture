using FluentValidation;

namespace Application.Roles.Commands.UpdateRole;

internal class ActivateRoleValidator : AbstractValidator<ActivateDeactivateRoleCommand>
{
    public ActivateRoleValidator()
    {
        RuleFor(x => x.RoleId).NotEmpty();
        RuleFor(x => x.Flag).NotEmpty();
    }


}
