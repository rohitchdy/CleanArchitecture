﻿namespace Api.Requests.Authentication;

public record LoginRequest
(
    string Email,
    string Password
);
