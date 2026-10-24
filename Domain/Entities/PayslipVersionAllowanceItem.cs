namespace Employee_Self_Service_Capstone.Domain.Entities;

public class PayslipVersionAllowanceItem
{
    public int Id { get; set; }

    public int PayslipVersionId { get; set; }
    public PayslipVersion PayslipVersion { get; set; } = null!;

    public string Name { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}