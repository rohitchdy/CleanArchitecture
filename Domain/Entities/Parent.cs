
namespace Domain.Entities;

public class Parent
{
    public Guid ParentId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Occupation { get; set; }
    public Guid? UserId { get; set; }
    public required User User { get; set; }
    public Guid StudentId { get; set; }
    public required Student Student { get; set; }
    public bool IsActive { get; set; }
}
