namespace Domain.Entities;
public class Enrollment
{
    public Guid EnrollmentId { get; set; }
    public int StudentId { get; set; }
    public int ClassId { get; set; }
    public string EnrollmentYear { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public string EnrollmentStatus { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public required List<Student> Students { get; set; }
    public required List<Class> Classes { get; set; }
    public List<EnrollmentExam>? EnrollmentExams { get; set; }

}
