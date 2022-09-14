using Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Commands.Register.RegisterCommand;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
