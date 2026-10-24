namespace Employee_Self_Service_Capstone.DTOs.Response;

public class PayslipResponseDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string EmployeeNumber { get; set; } = string.Empty;

    public int Month { get; set; }
    public int Year { get; set; }
    public string Status { get; set; } = string.Empty; // Draft, Published, Superseded

    public int CurrentVersionNumber { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal GrossPay { get; set; }
    public decimal TotalDeductions { get; set; }
    public decimal NetPay { get; set; }
    public string Currency { get; set; } = "NGN";
    public DateTime? PublishedAt { get; set; }

    public List<PayslipItemDetailDto> Allowances { get; set; } = new();
    public List<PayslipItemDetailDto> Deductions { get; set; } = new();
}