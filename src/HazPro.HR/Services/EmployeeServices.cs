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

    public async Task<Employee> AddEmployeeAsync(EmployeeDto employeeDto)
    {
        Employee employee = new Employee(employeeDto.EmployeeId, employeeDto.FullName.Split(" ")[0],
            employeeDto.FullName.Split(" ")[1],
            employeeDto.DateOfHire, employeeDto.Position, employeeDto.Department, 10);

        await _employeeRepository.AddAsync(employee);
        
        return employee;
    }

    public async Task<bool> UpdateEmployeeAsync(EmployeeDto reqEmployeeDto)
    {
        Employee employeeOld = await _employeeRepository.GetByIdAsync(reqEmployeeDto.EmployeeId);
        Employee employeeNew = new Employee(employeeOld.EmployeeId, reqEmployeeDto.FullName.Split(" ")[0],
            reqEmployeeDto.FullName.Split(" ")[1], employeeOld.DateOfHire, employeeOld.Position,
            employeeOld.DepartmentName, 20);
        
        await _employeeRepository.UpdateAsync(employeeNew);
        
        return true;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        Employee employee = await _employeeRepository.GetByIdAsync(id);
        await _employeeRepository.DeleteAsync(employee);
        return true;
    }
}