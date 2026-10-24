namespace Employee_Self_Service_Capstone.Domain.Entities;

public class CourseAssessment
{
    public int Id { get; set; } 
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public ICollection<AssessmentQuestion> Questions { get; set; } = new List<AssessmentQuestion>();

}