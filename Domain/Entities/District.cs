namespace Domain.Entities;

public class District
{
    public Guid DistrictId { get; set; }
    public string DistrictName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public Guid ProvinceId { get; set; }
    public required Province Province { get; set; }
    public required List<Municipality> Municipalities { get; set; }
    public required List<Student> Students { get; set; }
    public required List<Employee> Employees { get; set; }

}
