namespace Employee_Self_Service_Capstone.DTOs.Response;

public class TrainingEvidenceResponseDto
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public string EvidenceType { get; set; } = string.Empty;
    public string CompletionStatus { get; set; } = string.Empty;
    public string? ReviewComment { get; set; }
    public DateTime CreatedAt { get; set; } 
}