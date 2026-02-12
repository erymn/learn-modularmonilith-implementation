using HazPro.HR.Model;

namespace HazPro.HR.Services;

internal class EmployeeServices : IEmployeeServices
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