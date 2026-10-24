namespace Employee_Self_Service_Capstone.DTOs.Response;

public class VacancyApplicationResponseDto
{
    public int Id { get; set; }
    public int VacancyId { get; set; }
    public string VacancyTitle { get; set; } = string.Empty;
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;

    public string SupportingStatement { get; set; } = string.Empty;
    public string? AttachmentPath { get; set; }
    public string Status { get; set; } = string.Empty; 
    public DateTime AppliedAt { get; set; }
}