namespace Employee_Self_Service_Capstone.DTOs.Response;

public class EstacodeRateResponseDto
{
    public int Id { get; set; }
    public string CountryCode { get; set; } = string.Empty;
    public int GradeId { get; set; }
    public string GradeName { get; set; } = string.Empty;
    public decimal DailyRateUsd { get; set; }
}