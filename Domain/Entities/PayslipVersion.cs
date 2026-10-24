using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class PayslipVersion
{
    public int Id { get; set; }
    public int PayslipId { get; set; }
    public Payslip Payslip { get; set; } = null!;
    public int VersionNumber { get; set; } = 1;
    public decimal BasicSalary { get; set; }
    public decimal GrossPay { get; set; }
    public decimal TotalDeductions { get; set; }
    public decimal NetPay { get; set; }
    public string Currency { get; set; } = "NGN";
    public bool IsCurrent { get; set; } = true;
    public bool IsSuperseded { get; set; } = false;
    public PayslipStatus Status { get; set; } = PayslipStatus.Draft;
    public string? ChangeReason { get; set; }
    public string? FilePath { get; set; }
    public int CreatedById { get; set; }
    public Employee CreatedBy { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? PublishedAt { get; set; }
    public ICollection<PayslipVersionAllowanceItem> Allowances { get; set; } = new List<PayslipVersionAllowanceItem>();
    public ICollection<PayslipVersionDeductionItem> Deductions { get; set; } = new List<PayslipVersionDeductionItem>();
}