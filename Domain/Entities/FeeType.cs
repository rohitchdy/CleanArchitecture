namespace Domain.Entities;

public class FeeType
{
    public Guid FeeTypeId { get; set; }
    public string FeeTypeName { get; set; } = string.Empty;
    public string FeeTypeDescription { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public FeeStructure? FeeStructure { get; set; }
}
