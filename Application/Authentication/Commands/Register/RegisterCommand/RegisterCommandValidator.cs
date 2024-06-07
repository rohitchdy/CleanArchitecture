using Application.Commands.Register.RegisterCommand;
using FluentValidation;
using MediatR;
namespace Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required");
        RuleFor(x => x.Password).NotEmpty().Length(8).Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                                .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits.")
                                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{PropertyName}' must contain one or more special characters.")
                                .Matches("^[^£# “”]*$").WithMessage("'{PropertyName}' must not contain the following characters £ # “” or spaces.");
        RuleFor(x => x.ContactNumber).NotEmpty();
    }
}
