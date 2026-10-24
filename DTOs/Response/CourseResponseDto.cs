namespace Employee_Self_Service_Capstone.DTOs.Response;

public class CourseResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int PassMark { get; set; }
    public bool IsPublished { get; set; }
    public int TotalLessons { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<LessonSummaryResponseDto> Lessons { get; set; } = new();
}