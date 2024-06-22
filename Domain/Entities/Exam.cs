namespace Domain.Entities;

public class Exam
{
    public Guid ExamId { get; set; }
    public Guid ExamTypeId { get; set; }
    public Guid ClassId { get; set; }
    public Guid SubjectId { get; set; }
    public DateTime ExamDate { get; set; }
    public DateTime ExamTime { get; set; }
    public double ToalMarks { get; set; }
    public double PassMarks { get; set; }
    public bool IsActive { get; set; }
    public required ExamType ExamType { get; set; }
    public required List<Class> Classes { get; set; }
    public required List<Subject> Subjects { get; set; }
    public List<EnrollmentExam>? EnrollmentExams { get; set; }
    public ExamResult? ExamResult { get; set; }
}
