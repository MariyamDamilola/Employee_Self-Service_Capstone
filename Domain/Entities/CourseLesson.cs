namespace Employee_Self_Service_Capstone.Domain.Entities;

public class CourseLesson
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public int OrderIndex { get; set; }

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
}