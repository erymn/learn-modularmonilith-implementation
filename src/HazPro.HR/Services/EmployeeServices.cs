using HazPro.HR.Model;
using HazPro.HR.Repositories;

namespace HazPro.HR.Services;

internal class HardCodedEmployeeServices
{
    public List<EmployeeDto> ListEmployees()
    {
        return new List<EmployeeDto>()
        {
            new EmployeeDto(1, "Ery MN", DateTime.Now, "Senior Dev", "IT Dev"),
            new EmployeeDto(2, "Nirwana", DateTime.Now, "Web Dev", "IT Dev"),
            new EmployeeDto(3, "Guns And Roses", DateTime.Now, "QA", "IT Dev")
        };
    }
}

internal class EmployeeServices : IEmployeeServices
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeServices(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<EmployeeDto>> ListEmployeesAsync()
    {
        //TODO: will implement this next
        return new List<EmployeeDto>();
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