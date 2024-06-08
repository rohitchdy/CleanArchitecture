namespace Domain.Entities;

public class TeacherSubjects
{
    public Guid TeacherSubjectId { get; set; }
    public Guid TeacherId { get; set; }
    public required Employee Teacher { get; set; }
    public Guid SubjectId { get; set; }
    public required Subject Subject { get; set; }

}
