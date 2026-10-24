namespace Employee_Self_Service_Capstone.Domain.Entities;

public class AssessmentResetHistory
{
    public int Id { get; set; }

    public int CourseAssignmentId { get; set; }
    public CourseAssignment CourseAssignment { get; set; } = null!;

    public int ResetById { get; set; }
    public Employee ResetBy { get; set; } = null!;

    public string Reason { get; set; } = string.Empty;
    public int CycleReset { get; set; }

    public DateTime ResetAtUtc { get; set; } = DateTime.UtcNow;
}