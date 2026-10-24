using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.DTOs.Request.Training;

public class ReviewTrainingEvidenceRequestDto
{
    public TrainingCompletionStatus Status { get; set; } 
    public string? ReviewComment { get; set; }
}