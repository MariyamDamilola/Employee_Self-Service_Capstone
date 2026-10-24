namespace Employee_Self_Service_Capstone.DTOs.Request.Courses;

public class AssignCourseRequestDto
{
    public int CourseId { get; set; }
    public List<int> EmployeeIds { get; set; } = new();
    public DateTime DueDate { get; set; }
}