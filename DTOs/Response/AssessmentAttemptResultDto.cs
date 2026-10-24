namespace Employee_Self_Service_Capstone.DTOs.Response;

public class AssessmentAttemptResultDto
{
    public int AttemptId { get; set; }
    public int AttemptNumber { get; set; }
    public decimal ScorePercentage { get; set; }
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public string ResultStatus { get; set; } = string.Empty; // Passed, Failed
    public bool CanRetake { get; set; }
    public DateTime AttemptedAt { get; set; }
}