namespace Employee_Self_Service_Capstone.DTOs.Request.Training;

public class ReassignTrainingReviewerRequestDto
{
    public int NewManagerId { get; set; }
    public string Reason { get; set; } = string.Empty;

}