using Employee_Self_Service_Capstone.Domain.Entities;

namespace Employee_Self_Service_Capstone.Repository.Interfaces;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(int departmentId);

    Task<Department?> GetByCodeAsync(string code);
    Task<IEnumerable<Department>> GetAllAsync();

    Task<bool> ExistsByNameAsync(string name);

    Task<bool> ExistsByCodeAsync(string code);

    Task AddAsync(Department department);

    Task<bool> SaveChangesAsync();
}