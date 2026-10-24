namespace Employee_Self_Service_Capstone.DTOs.Request.Courses;

public class CreateAssessmentOptionRequestDto
{
    public string OptionText { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
}