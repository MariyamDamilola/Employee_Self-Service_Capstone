namespace Employee_Self_Service_Capstone.DTOs.Response;

public class LessonSummaryResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int OrderIndex { get; set; }
    public string Content { get; set; } = string.Empty;
}