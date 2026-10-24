namespace Employee_Self_Service_Capstone.DTOs.Request.Notifications;

public class MarkNotificationReadRequestDto
{
    public List<int> NotificationIds { get; set; } = new();

}