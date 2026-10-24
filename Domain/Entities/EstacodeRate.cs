namespace Employee_Self_Service_Capstone.Domain.Entities;

public class EstacodeRate
{
    public int Id { get; set; }
    public string CountryCode { get; set; }
    public string GradeId { get; set; }
    public Grade Grade { get; set; }
    public decimal DailyRateUsd { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}