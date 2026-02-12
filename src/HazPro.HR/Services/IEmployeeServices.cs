using HazPro.HR.Model;

namespace HazPro.HR.Services;

public interface IEmployeeServices
{
    List<EmployeeDto> ListEmployees();
}