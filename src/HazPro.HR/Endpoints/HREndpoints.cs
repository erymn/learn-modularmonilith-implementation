using HazPro.HR.Model;
using HazPro.HR.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace HazPro.HR.Endpoints;

public static class HREndpoints
{
    public static void MapHREndpoints(this WebApplication app)
    {
        app.MapGet("/hr/employees", ([FromServices] IEmployeeServices employeeService) =>
        {
            return employeeService.ListEmployeesAsync();
        });
    }
}