namespace Employee_Self_Service_Capstone.DTOs.Request.Payslips;

public class CreatePayslipRequestDto
{
    public int EmployeeId { get; set; }
    public int Month { get; set; } 
    public int Year { get; set; }
    public decimal BasicSalary { get; set; }
    public List<PayslipItemRequestDto> Allowances { get; set; } = new();
    public List<PayslipItemRequestDto> Deductions { get; set; } = new();
}