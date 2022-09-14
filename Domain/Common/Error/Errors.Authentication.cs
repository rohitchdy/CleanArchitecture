
namespace Domain.Common.Error;
using ErrorOr;
public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCrediential => Error.Conflict(code: "Auth.InvalidCrediential", description: "Invalid Credential");
    }
}
