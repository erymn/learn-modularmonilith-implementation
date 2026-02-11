using HazPro.HR.Model;
using HazPro.HR.Services;
using Microsoft.AspNetCore.Builder;

namespace HazPro.HR.Endpoints;

internal static class HREndpoints
{
    public static void MapHREndpoints(this WebApplication app)
    {
        app.MapGet("/hr/employees", (EmployeeServices employeeService) =>
        {
            return employeeService.ListEmployees();
        });
    }
}