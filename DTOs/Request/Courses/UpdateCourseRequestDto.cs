namespace Employee_Self_Service_Capstone.DTOs.Request.Courses;

public class UpdateCourseRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int PassMark { get; set; }
}