using FastEndpoints;
using HazPro.HR.Services;
using Microsoft.AspNetCore.Mvc;

namespace HazPro.HR.Endpoints.Employees;

public class DeleteEmployee : Endpoint<DeleteEmployeeRequest>
{
    private readonly IEmployeeServices _employeeServices;

    public DeleteEmployee(IEmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }

    public override void Configure()
    {
        Delete("/api/hr/employees/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteEmployeeRequest req, CancellationToken ct)
    {
        var success = await _employeeServices.DeleteEmployeeAsync(req.Id);
        if (!success)
        {
            await Send.NotFoundAsync(ct);
        }
        else
        {
            await Send.NoContentAsync(ct);
        }
    }
}

public class DeleteEmployeeRequest
{
    [FromRoute] public int Id { get; set; }
}