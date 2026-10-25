using Employee_Self_Service_Capstone.Data;
using Employee_Self_Service_Capstone.Domain.Entities;
using Employee_Self_Service_Capstone.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee_Self_Service_Capstone.Repository.Implementations;

public class NotificationRepository : INotificationRepository
{
    private readonly AppDbContext _context;

    public NotificationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Notification?> GetByIdAsync(int id)
    {
        return await _context.Notifications
            .FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task<IEnumerable<Notification>> GetUserNotificationsAsync(int recipientUserId, bool unreadOnly = false)
    {
        var query = _context.Notifications
            .Where(n => n.EmployeeId == recipientUserId);

        if (unreadOnly)
        {
            query = query.Where(n => !n.IsRead);
        }

        return await query
            .OrderByDescending(n => n.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> GetUnreadCountAsync(int recipientUserId)
    {
        return await _context.Notifications
            .CountAsync(n => n.EmployeeId == recipientUserId && !n.IsRead);
    }

    public async Task<bool> NotificationKeyExistsAsync(string deduplicationKey)
    {
        if (string.IsNullOrWhiteSpace(deduplicationKey))
        {
            return false;
        }

        return await _context.Notifications
            .AnyAsync(n => n.DeduplicationKey == deduplicationKey);
    }

    public async Task MarkAllAsReadAsync(int recipientUserId)
    {
        var unreadNotifications = await _context.Notifications
            .Where(n => n.EmployeeId == recipientUserId && !n.IsRead)
            .ToListAsync();

        if (unreadNotifications.Count == 0)
        {
            return;
        }

        var utcNow = DateTime.UtcNow;
        foreach (var notification in unreadNotifications)
        {
            notification.IsRead = true;
            notification.ReadAt = utcNow;
        }

        await _context.SaveChangesAsync();
    }

    public async Task AddAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
    }

    public Task UpdateAsync(Notification notification)
    {
        _context.Notifications.Update(notification);
        return Task.CompletedTask;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}