using HazPro.HR.Model;

namespace HazPro.HR.Services;

internal interface IEmployeeServices
{
    Task<List<EmployeeDto>> ListEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync(int id);
}