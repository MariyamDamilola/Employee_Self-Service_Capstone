namespace Employee_Self_Service_Capstone.Domain.Entities;

public class LessonProgress
{
    public int Id { get; set; }

    public int CourseAssignmentId { get; set; }
    public CourseAssignment CourseAssignment { get; set; } = null!;
    public int CourseLessonId { get; set; }
    public CourseLesson CourseLesson { get; set; } = null!;
    public DateTime CompletedAtUtc { get; set; } = DateTime.UtcNow;
}