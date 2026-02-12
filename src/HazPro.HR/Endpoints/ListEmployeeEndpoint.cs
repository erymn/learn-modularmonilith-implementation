using FastEndpoints;
using HazPro.HR.Model;
using HazPro.HR.Services;

namespace HazPro.HR.Endpoints;

public class ListEmployeeEndpoint : EndpointWithoutRequest<List<EmployeeDto>>
{
    private readonly IEmployeeServices _employeeServices;

    public ListEmployeeEndpoint(IEmployeeServices employeeServices)
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
        List<EmployeeDto> employees = _employeeServices.ListEmployees();
        await Send.OkAsync(employees);
    }
}