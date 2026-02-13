using HazPro.HR.Model;

namespace HazPro.HR.Services;

public interface IEmployeeServices
{
    Task<List<EmployeeDto>> ListEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync(int id);
}