using Application.Common.Interfaces.Persistence;
using Azure.Core;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    private static readonly List<User> _users = new();
    public void AddUser(User user)
    {
        //_users.Add(user);
        _userManager.CreateAsync(user, user.Password);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
