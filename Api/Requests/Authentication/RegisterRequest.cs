﻿namespace Api.Requests.Authentication;
public record RegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ContactNumber
);