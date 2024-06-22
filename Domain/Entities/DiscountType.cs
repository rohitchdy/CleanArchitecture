namespace Domain.Entities;

public class DiscountType
{
    public Guid DiscountTypeId { get; set; }
    public string DiscountTypeName { get; set; } = string.Empty;
    public string DiscountDescription { get; set; } = string.Empty;
    public decimal DiscountAmount { get; set; }
    public bool IsActive { get; set; }
    public FeeStructure? FeeStructure { get; set; }
}
