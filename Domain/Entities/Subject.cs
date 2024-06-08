
namespace Domain.Entities;
public class Subject
{
    public Guid SubjectId { get; set; }
    public String SubjectName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Credits { get; set; }
    public int HoursPerWeek { get; set; }
    public bool IsActive { get; set; }
    public Guid ClassId { get; set; }
    public required Class Class { get; set; }
    public required List<TeacherSubjects> TeacherSubjects { get; set; }
}
