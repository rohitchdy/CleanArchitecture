namespace Domain.Common.Error;
using ErrorOr;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(code: "User.Duplicate", description: "Email is already in use");
    }

    public static class Role
    {
        public static Error DuplicateRole => Error.Conflict(code: "Role.Duplicate", description: "Role already exists");
        public static Error RoleNotFound => Error.NotFound(code: "Role.NotFound", description: "Role not found");
    }

}