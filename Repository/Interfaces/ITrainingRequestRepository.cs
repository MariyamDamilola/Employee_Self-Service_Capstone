using Employee_Self_Service_Capstone.Domain.Entities;

namespace Employee_Self_Service_Capstone.Repository.Interfaces;

public interface ITrainingRequestRepository
{
    Task<TrainingRequest?> GetByIdAsync(int id);

    Task<TrainingRequest?> GetWithDetailsAsync(int id);

    Task<IEnumerable<TrainingRequest>> GetByEmployeeIdAsync(int employeeId);

    Task<IEnumerable<TrainingRequest>> GetPendingApprovalsByReviewerAsync(int reviewerId);

    Task<bool> HasOverlappingApprovedTrainingAsync(int employeeId, DateTime startDate, DateTime endDate, int? excludeRequestId = null);

    Task AddAsync(TrainingRequest trainingRequest);

    Task UpdateAsync(TrainingRequest trainingRequest);

    Task<bool> SaveChangesAsync();
}