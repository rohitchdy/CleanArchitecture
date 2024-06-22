namespace Domain.Entities;

public class ExamType
{
    public Guid ExamTypeId { get; set; }
    public string ExamTypeName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<Exam>? Exams { get; set; }
}
