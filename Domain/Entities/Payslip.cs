using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class Payslip
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public int Month { get; set; } 
    public int Year { get; set; }
    
    public int CurrentVersionNumber { get; set; } = 1;
    public PayslipStatus Status { get; set; } = PayslipStatus.Draft;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public ICollection<PayslipVersion> Versions { get; set; } = new List<PayslipVersion>();

}