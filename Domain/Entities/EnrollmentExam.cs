namespace Domain.Entities;

public class EnrollmentExam
{
    public Guid EnrollmentExamId { get; set; }
    public Guid EnrollmentId { get; set; }
    public Guid ExamId { get; set; }
    public bool IsActive { get; set; }
    public required Exam Exam { get; set; }
    public required Enrollment Enrollment { get; set; }

}
