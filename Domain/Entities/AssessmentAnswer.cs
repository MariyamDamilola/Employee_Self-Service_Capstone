namespace Employee_Self_Service_Capstone.Domain.Entities;

public class AssessmentAnswer
{
    public int Id { get; set; }
    public int AssessmentAttemptId { get; set; }
    public AssessmentAttempt AssessmentAttempt { get; set; } = null!;
    public int AssessmentQuestionId { get; set; }
    public AssessmentQuestion AssessmentQuestion { get; set; } = null!;
    public int SelectedOptionId { get; set; }
    public AssessmentOption SelectedOption { get; set; } = null!;
    public bool IsCorrect { get; set; }
}