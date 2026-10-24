using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class TrainingEvidence
{
    public int Id { get; set; }
    public int TrainingRequestId { get; set; }
    public virtual TrainingRequest TrainingRequest { get; set; } = null!;
    public TrainingEvidenceType EvidenceType { get; set; }
    public int UploadedById { get; set; }
    public virtual Employee UploadedBy { get; set; } = null!;
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public TrainingCompletionStatus Status { get; set; } = TrainingCompletionStatus.Submitted;
    public string? ReviewComment { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ReviewedAt { get; set; }
}