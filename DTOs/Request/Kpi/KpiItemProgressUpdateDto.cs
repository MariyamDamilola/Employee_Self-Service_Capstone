namespace Employee_Self_Service_Capstone.DTOs.Request.Kpi;

public class KpiItemProgressUpdateDto
{
    public int KpiItemId { get; set; }
    public decimal ActualValue { get; set; }
    public string? EvidenceComments { get; set; }
}