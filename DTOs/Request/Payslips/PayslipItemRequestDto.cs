namespace Employee_Self_Service_Capstone.DTOs.Request.Payslips;

public class PayslipItemRequestDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}