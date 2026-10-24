namespace Employee_Self_Service_Capstone.DTOs.Response;

public class CourseAssignmentResponseDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string CourseTitle { get; set; } = string.Empty;
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool IsOverdue { get; set; }
    public DateTime DueDate { get; set; }
    public decimal? BestScore { get; set; }
    public int AttemptsUsed { get; set; }
    public DateTime? CompletedAt { get; set; }
}