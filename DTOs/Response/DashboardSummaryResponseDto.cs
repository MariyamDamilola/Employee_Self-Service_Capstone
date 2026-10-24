namespace Employee_Self_Service_Capstone.DTOs.Response;

public class DashboardSummaryResponseDto
{
    public int PendingTrainingApprovalsCount { get; set; }
    public int IncompleteCoursesCount { get; set; }
    public int OverdueCoursesCount { get; set; }
    public int ActiveKpiPlansCount { get; set; }
    public int OpenVacanciesCount { get; set; }
    public int UnreadNotificationsCount { get; set; }
}