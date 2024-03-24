﻿using Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
