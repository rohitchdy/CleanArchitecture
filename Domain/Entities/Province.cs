namespace Domain.Entities;

public class Province
{
    public Guid ProvinceId { get; set; }
    public string ProvinceName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<District>? Districts { get; set; }
    public List<Student>? Students { get; set; }
    public List<Employee>? Employees { get; set; }
}
