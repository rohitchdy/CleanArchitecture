namespace Domain.Entities;

public class EnrollmentYear
{
    public Guid EnrollmentYearId { get; set; }
    public string EnrollemntYearName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
