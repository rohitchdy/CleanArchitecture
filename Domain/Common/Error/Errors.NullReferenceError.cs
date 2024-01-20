namespace Domain.Common.Error;
using ErrorOr;
public static partial class Errors
{
    public static Error NullReferenceError(string propertyName)
    {
        return Error.NotFound(code: "Object.NullReference", description: $"{propertyName} is null or not found");
    }
}
