﻿using Microsoft.AspNetCore.Identity;
namespace Domain.Entities;

public class User :IdentityUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    //public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
