
namespace Domain.Entities;

public class Class
{
    public Guid ClassId { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public required List<Subject> Subjects { get; set; }

}
