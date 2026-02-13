using HazPro.HR.Model;
using HazPro.HR.Repositories;

namespace HazPro.HR.Services;

internal class EmployeeServices : IEmployeeServices
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeServices(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<EmployeeDto>> ListEmployeesAsync()
    {
        var employees = await _employeeRepository.ListAllAsync();
        return employees.Select(e => new EmployeeDto(
            e.EmployeeId,
            $"{e.FirstName} {e.LastName}",
            e.DateOfHire,
            e.Position,
            e.DepartmentName
        )).ToList();
    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        return new EmployeeDto(
            employee.EmployeeId,
            $"{employee.FirstName} {employee.LastName}",
            employee.DateOfHire,
            employee.Position,
            employee.DepartmentName
        );
    }
}