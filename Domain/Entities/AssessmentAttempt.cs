using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class AssessmentAttempt
{
    public int Id { get; set; }

    public int CourseAssignmentId { get; set; }
    public CourseAssignment CourseAssignment { get; set; } = null!;

    public int AttemptNumber { get; set; }

    public int CycleNumber { get; set; }

    public decimal Score { get; set; }

    public bool IsPassed { get; set; }

    public DateTime SubmittedAtUtc { get; set; } = DateTime.UtcNow;

    public ICollection<AssessmentAnswer> Answers { get; set; } = new List<AssessmentAnswer>();
}