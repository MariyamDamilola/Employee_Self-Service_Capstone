using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.DTOs.Request.Courses;

public class CreateAssessmentQuestionRequestDto
{
    public string QuestionText { get; set; } = string.Empty;
    public List<CreateAssessmentOptionRequestDto> Options { get; set; } = new();

}