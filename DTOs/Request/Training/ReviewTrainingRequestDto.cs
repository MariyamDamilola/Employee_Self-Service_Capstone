using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.DTOs.Request.Training;

public class ReviewTrainingRequestDto
{
    public ApprovalAction Action { get; set; } 
    public string? Comments { get; set; }
}