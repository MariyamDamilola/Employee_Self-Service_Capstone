using Employee_Self_Service_Capstone.Data;
using Employee_Self_Service_Capstone.Domain.Entities;
using Employee_Self_Service_Capstone.Domain.Enum;
using Employee_Self_Service_Capstone.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee_Self_Service_Capstone.Repository.Implementations;

public class TrainingRequestRepository : ITrainingRequestRepository
{
    private readonly AppDbContext _context;

    public TrainingRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TrainingRequest?> GetByIdAsync(int id)
    {
        return await _context.TrainingRequests
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TrainingRequest?> GetWithDetailsAsync(int id)
    {
        return await _context.TrainingRequests
            .Include(t => t.Employee)
            .Include(t => t.AssignedReviewer)
            .Include(t => t.Allowances)
            .Include(t => t.ApprovalHistories)
            .Include(t => t.EvidenceFiles)
            .Include(t => t.Comments)
            .Include(t => t.AssignmentHistories)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<TrainingRequest>> GetByEmployeeIdAsync(int employeeId)
    {
        return await _context.TrainingRequests
            .Include(t => t.AssignedReviewer)
            .Where(t => t.EmployeeId == employeeId)
            .OrderByDescending(t => t.CreatedAtUtc)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<TrainingRequest>> GetPendingApprovalsByReviewerAsync(int reviewerId)
    {
        return await _context.TrainingRequests
            .Include(t => t.Employee)
            .Where(t => t.AssignedReviewerId == reviewerId &&
                        (t.Status == TrainingRequestStatus.PendingManagerApproval ||
                         t.Status == TrainingRequestStatus.PendingHRApproval ||
                         t.Status == TrainingRequestStatus.PendingFinanceApproval))
            .OrderByDescending(t => t.CreatedAtUtc)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> HasOverlappingApprovedTrainingAsync(
        int employeeId,
        DateTime startDate,
        DateTime endDate,
        int? excludeRequestId = null)
    {
        return await _context.TrainingRequests
            .AnyAsync(t =>
                t.EmployeeId == employeeId &&
                t.Status == TrainingRequestStatus.Approved &&
                (!excludeRequestId.HasValue || t.Id != excludeRequestId.Value) &&
                t.TrainingStartDate <= endDate &&
                t.TrainingEndDate >= startDate);
    }

    public async Task AddAsync(TrainingRequest trainingRequest)
    {
        await _context.TrainingRequests.AddAsync(trainingRequest);
    }

    public Task UpdateAsync(TrainingRequest trainingRequest)
    {
        _context.TrainingRequests.Update(trainingRequest);
        return Task.CompletedTask;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}