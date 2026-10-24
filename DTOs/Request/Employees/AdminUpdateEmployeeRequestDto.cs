namespace Employee_Self_Service_Capstone.DTOs.Request.Employees;

public class AdminUpdateEmployeeRequestDto
{
    public string FullName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public int DepartmentId { get; set; }
    public int GradeId { get; set; }
    public int? ReportingManagerId { get; set; }
    public List<int> RoleIds { get; set; } = new();
}