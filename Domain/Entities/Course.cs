namespace Employee_Self_Service_Capstone.Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    
    public int PassMark { get; set; }
    public bool IsPublished { get; set; } = false;

    public int CreatedById { get; set; }
    public Employee CreatedBy { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? PublishedAtUtc { get; set; }
    
    public CourseAssessment? Assessment { get; set; }
    public ICollection<CourseLesson> Lessons { get; set; } = new List<CourseLesson>();
    public ICollection<CourseAssignment> Assignments { get; set; } = new List<CourseAssignment>();
}