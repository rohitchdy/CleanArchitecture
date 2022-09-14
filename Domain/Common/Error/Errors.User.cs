namespace Domain.Common.Error;
using ErrorOr;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(code: "User.Duplicate", description: "Email is already in use");
    }
}