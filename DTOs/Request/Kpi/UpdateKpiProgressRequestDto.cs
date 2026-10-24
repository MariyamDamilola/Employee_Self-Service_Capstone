namespace Employee_Self_Service_Capstone.DTOs.Request.Kpi;

public class UpdateKpiProgressRequestDto
{
    public List<KpiItemProgressUpdateDto> Items { get; set; } = new();
}