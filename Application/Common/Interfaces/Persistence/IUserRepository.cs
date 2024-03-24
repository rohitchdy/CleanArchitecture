using Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
    List<User> GetUsers();
    User? GetUserById(Guid userId);
    User? UpdateUser(User user);
}
