namespace Employee_Self_Service_Capstone.DTOs.Request.Courses;

public class SubmitAssessmentRequestDto
{
    public List<AssessmentAnswerRequestDto> Answers { get; set; } = new();
}