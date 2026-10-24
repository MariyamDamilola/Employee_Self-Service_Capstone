namespace Employee_Self_Service_Capstone.Domain.Entities;

public class PayslipVersionDeductionItem
{
    public int Id { get; set; }
    public int PayslipVersionId { get; set; }
    public PayslipVersion PayslipVersion { get; set; } 
    public string Name { get; set; }
    public decimal Amount { get; set; }
}