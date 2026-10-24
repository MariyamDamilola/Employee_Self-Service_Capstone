using Employee_Self_Service_Capstone.Domain.Entities;

namespace Employee_Self_Service_Capstone.Repository.Interfaces;

public interface INotificationRepository
{
    Task<Notification?> GetByIdAsync(int id);

    Task<IReadOnlyList<Notification>> GetUserNotificationsAsync(int recipientUserId, bool unreadOnly = false);

    Task<int> GetUnreadCountAsync(int recipientUserId);

    Task<bool> NotificationKeyExistsAsync(string deduplicationKey);

    Task MarkAllAsReadAsync(int recipientUserId);

    Task AddAsync(Notification notification);

    Task UpdateAsync(Notification notification);

    Task<bool> SaveChangesAsync();
}