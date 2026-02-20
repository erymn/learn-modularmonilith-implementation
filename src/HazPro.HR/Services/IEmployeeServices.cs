using Ardalis.Result;
using HazPro.HR.Model;

namespace HazPro.HR.Services;

public interface IEmployeeServices
{
    Task<List<EmployeeDto>> ListEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync(int id);
    Task<EmployeeDto> AddEmployeeAsync(EmployeeDto employee);
    Task<bool> UpdateEmployeeAsync(EmployeeDto reqEmployeeDto);
    Task<bool> DeleteEmployeeAsync(int id);
    Task<Result<bool>> UpdateEmployeeWageAsync(int id, decimal newHourlyWage);
}