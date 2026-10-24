namespace Employee_Self_Service_Capstone.DTOs.Response;

public class EmployeeProfileResponseDto
{
    public int Id { get; set; }
    public string EmployeeNumber { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }

    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;

    public int GradeId { get; set; }
    public string GradeName { get; set; } = string.Empty;

    public int? ReportingManagerId { get; set; }
    public string? ReportingManagerName { get; set; }

    public string AccountStatus { get; set; } = string.Empty;
    public DateTime EmploymentStartDate { get; set; }
    public List<string> Roles { get; set; } = new();
}