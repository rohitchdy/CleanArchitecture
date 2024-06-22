
namespace Domain.Entities;

public class Employee
{
    public Guid EmployeeId { get; set; }
    public string EmployeeNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime JoiningDate { get; set; }
    public string Qualification { get; set; } = string.Empty;
    public string ExperienceInfo { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public Guid ProvinceId { get; set; }
    public required Province Province { get; set; }
    public Guid DistrictId { get; set; }
    public required District District { get; set; }

    public Guid MunicipalityId { get; set; }
    public required Municipality Municipality { get; set; }
    public Guid UserId { get; set; }
    public required User User { get; set; }
    public bool IsActive { get; set; }
    public required string Status { get; set; }

    public List<TeacherSubjects>? TeacherSubjects { get; set; }
}
