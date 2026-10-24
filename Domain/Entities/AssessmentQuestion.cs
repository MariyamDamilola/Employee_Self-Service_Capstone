using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class AssessmentQuestion
{
    public int Id { get; set; }

    public int CourseAssessmentId { get; set; }
    public CourseAssessment CourseAssessment { get; set; } = null!;

    public string QuestionText { get; set; } = string.Empty;

    public ICollection<AssessmentOption> Options { get; set; } = new List<AssessmentOption>();
}