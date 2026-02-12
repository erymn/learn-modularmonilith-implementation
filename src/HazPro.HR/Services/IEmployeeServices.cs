using HazPro.HR.Model;

namespace HazPro.HR.Services;

internal interface IEmployeeServices
{
    List<EmployeeDto> ListEmployees();
}