using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class CourseAssignment
{
    public int Id { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public DateTime DueDate { get; set; }

    public CourseAssignmentStatus Status { get; set; } = CourseAssignmentStatus.NotStarted;

    public int AttemptsUsed { get; set; } = 0;

    public decimal? BestScore { get; set; }
    public int CycleNumber { get; set; } = 1;

    public DateTime? CompletedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
    public ICollection<AssessmentAttempt> Attempts { get; set; } = new List<AssessmentAttempt>();
    public ICollection<AssessmentResetHistory> ResetHistories { get; set; } = new List<AssessmentResetHistory>();

    
}