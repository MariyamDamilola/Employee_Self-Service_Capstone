using Employee_Self_Service_Capstone.Domain.Entities;

namespace Employee_Self_Service_Capstone.Repository.Interfaces;

public interface IPayslipRepository
{
    
    Task<Payslip?> GetByIdAsync(int id);

    Task<Payslip?> GetPayslipWithDetailsAsync(int id);

    Task<Payslip?> GetEmployeePayslipByPeriodAsync(int employeeId, int month, int year);

    Task<IEnumerable<Payslip>> GetEmployeePayslipsAsync(int employeeId, int? year = null);

    Task<bool> PayslipExistsForPeriodAsync(int employeeId, int month, int year);

    Task AddAsync(Payslip payslip);

    Task UpdateAsync(Payslip payslip);

    Task<bool> SaveChangesAsync();
}