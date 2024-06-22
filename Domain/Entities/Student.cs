namespace Domain.Entities;

public class Student
{
    public Guid StudentId { get; set; }
    public string StudentNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public Guid ProvinceId { get; set; }
    public required Province Province { get; set; }

    public Guid DistrictId { get; set; }
    public required District District { get; set; }

    public Guid MunicipalityId { get; set; }
    public required Municipality Municipality { get; set; }

    public bool IsActive { get; set; }
    public string Status { get; set; } = string.Empty;

    public Parent? Parent { get; set; }
    public Enrollment? Enrollment { get; set; }

    public ExamResult? ExamResult { get; set; }
}
