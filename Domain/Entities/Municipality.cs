
namespace Domain.Entities;

public class Municipality
{
    public Guid MunicipalityId { get; set; }
    public string MunicipalityName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public Guid DistrictId { get; set; }
    public int WardCount { get; set; }
    public required District District { get; set; }
    public required List<Student> Students { get; set; }
    public required List<Employee> Employees { get; set; }

}
