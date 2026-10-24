using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class TrainingRequestComment
{
    public int Id { get; set; }

    public int TrainingRequestId { get; set; }
    public TrainingRequest TrainingRequest { get; set; }
    public TrainingRequestCommentType CommentType { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}