namespace Application.Common.Interfaces.Authentication;
public interface IPasswordHasher
{
    string GenerateHashPassword(string password);
    bool VerifyPassword(string requestPassword, string savedPassword);
}
