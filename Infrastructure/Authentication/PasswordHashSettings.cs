namespace Infrastructure.Authentication;

public class PasswordHashSettings
{
    public const string SectionName = "PasswordHashSettings";
    public string Salt { get; set; } = null!;
}
