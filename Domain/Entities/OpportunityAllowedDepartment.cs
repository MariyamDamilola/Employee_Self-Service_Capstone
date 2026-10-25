namespace Employee_Self_Service_Capstone.Domain.Entities;

public class OpportunityAllowedDepartment
{
    public int Id { get; set; }
    public int InternalOpportunityId { get; set; }
    public InternalOpportunity InternalOpportunity { get; set; } = null!;
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
}