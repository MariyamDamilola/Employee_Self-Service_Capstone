namespace Employee_Self_Service_Capstone.DTOs.Request.Kpi;

public class CreateKpiItemRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Target { get; set; }
    public string Unit { get; set; } = string.Empty;
    public decimal Weight { get; set; }
}