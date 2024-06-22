
namespace Domain.Entities;

public class Class
{
    public Guid ClassId { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<Subject>? Subjects { get; set; }
    public Enrollment? Enrollment { get; set; }
    public Exam? Exam { get; set; }
    public FeeStructure? FeeStructure { get; set; }

}
