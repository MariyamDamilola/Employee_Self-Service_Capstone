namespace Employee_Self_Service_Capstone.DTOs.Request.Courses;

public class UpdateLessonProgressRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int OrderIndex { get; set; }
}