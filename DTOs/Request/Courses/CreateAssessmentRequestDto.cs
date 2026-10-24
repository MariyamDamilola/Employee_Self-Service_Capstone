namespace Employee_Self_Service_Capstone.DTOs.Request.Courses;

public class CreateAssessmentRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<CreateAssessmentQuestionRequestDto> Questions { get; set; } = new();


}