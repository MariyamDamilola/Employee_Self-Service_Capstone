namespace Employee_Self_Service_Capstone.DTOs.Request.Payslips;

public class CreatePayslipRevisionRequestDto
{
    public string ChangeReason { get; set; } = string.Empty;
    public decimal BasicSalary { get; set; }
    public List<PayslipItemRequestDto> Allowances { get; set; } = new();
    public List<PayslipItemRequestDto> Deductions { get; set; } = new();
}