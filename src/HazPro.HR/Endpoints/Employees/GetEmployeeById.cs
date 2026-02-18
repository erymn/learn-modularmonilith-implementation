using FastEndpoints;
using HazPro.HR.Services;
using Microsoft.AspNetCore.Mvc;

namespace HazPro.HR.Endpoints.Employees;

public class GetEmployeeById : Endpoint<GetEmployeeByIdRequest>
{
    private readonly IEmployeeServices _employeeServices;

    public GetEmployeeById(IEmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }

    public override void Configure()
    {
        Get("/api/hr/employees/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetEmployeeByIdRequest req, CancellationToken ct)
    {
        var employee = await _employeeServices.GetEmployeeByIdAsync(req.Id);
        if (employee == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        else
        {
            await Send.OkAsync(employee, ct);
        }
    }
}

public record GetEmployeeByIdRequest()
{
    [FromRoute] public int Id { get; init; }
}
