namespace Domain.Entities;

public class FeeStructure
{
    public Guid FeeStructureId { get; set; }
    public string EnrollmentYear { get; set; } = string.Empty;
    public Guid ClassId { get; set; }
    public Guid FeeTypeId { get; set; }
    public decimal Amount { get; set; }
    public Guid DiscountTypeId { get; set; }
    public bool IsActive { get; set; }
    public required Class Class { get; set; }
    public required List<FeeType> FeeTypes { get; set; }
    public required DiscountType DiscountType { get; set; }
}
