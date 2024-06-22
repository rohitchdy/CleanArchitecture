namespace Domain.Entities;

public class ExamResult
{
    public Guid ExamResultId { get; set; }
    public Guid ExamId { get; set; }
    public Guid StudentId { get; set; }
    public decimal MarksObtained { get; set; }
    public bool IsActive { get; set; }
    public required Exam Exam { get; set; }
    public required Student Student { get; set; }
}
