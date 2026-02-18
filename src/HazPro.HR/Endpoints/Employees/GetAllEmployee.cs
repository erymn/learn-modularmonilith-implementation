using FastEndpoints;
using HazPro.HR.Services;

namespace HazPro.HR.Endpoints.Employees;

public class GetAllEmployee : EndpointWithoutRequest
{
    private readonly IEmployeeServices _employeeServices;

    public GetAllEmployee(IEmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }

    public override void Configure()
    {
        Get("/api/hr/employees");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var employees = await _employeeServices.ListEmployeesAsync();
        await Send.OkAsync(employees, ct);
    }
}