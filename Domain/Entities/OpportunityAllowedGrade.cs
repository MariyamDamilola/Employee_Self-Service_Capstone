namespace Employee_Self_Service_Capstone.Domain.Entities;

public class OpportunityAllowedGrade
{
    public int Id { get; set; }

    public int InternalOpportunityId { get; set; }
    public InternalOpportunity InternalOpportunity { get; set; } = null!;

    public int GradeId { get; set; }
    public Grade Grade { get; set; } = null!;

}