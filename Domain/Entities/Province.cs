namespace Domain.Entities;

public class Province
{
    public Guid ProvinceId { get; set; }
    public string ProvinceName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public required List<District> Districts { get; set; }
    public required List<Student> Students { get; set; }
    public required List<Employee> Employees { get; set; }
}
