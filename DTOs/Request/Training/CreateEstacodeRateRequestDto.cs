namespace Employee_Self_Service_Capstone.DTOs.Request.Training;

public class CreateEstacodeRateRequestDto
{
    public string CountryCode { get; set; } = string.Empty;
    public int GradeId { get; set; }
    public decimal DailyRateUsd { get; set; }
}