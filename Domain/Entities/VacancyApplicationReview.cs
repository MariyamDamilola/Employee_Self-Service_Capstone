using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class VacancyApplicationReview
{
    public int Id { get; set; }
    public int VacancyApplicationId { get; set; }
    public VacancyApplication VacancyApplication { get; set; } = null!;
    public int ReviewerId { get; set; }
    public Employee Reviewer { get; set; } = null!;

    public VacancyApplicationReviewDecision Decision { get; set; } 
    public string? Comments { get; set; }
    public DateTime ReviewedAtUtc { get; set; } = DateTime.UtcNow;
}