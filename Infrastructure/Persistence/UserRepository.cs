using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void AddUser(User user)
    {
        _dataContext.Users.Add(user);
        _dataContext.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return _dataContext.Users.SingleOrDefault(u => u.Email == email);
    }

    public User? GetUserById(Guid userId)
    {
        return _dataContext.Users.SingleOrDefault(u => u.Id == userId);
    }

    public List<User> GetUsers()
    {
        return _dataContext.Users.ToList();
    }

    public User? UpdateUser(User user)
    {
        _dataContext.Entry(user).State = EntityState.Modified;
        _dataContext.SaveChanges();
        return user;
    }
}
