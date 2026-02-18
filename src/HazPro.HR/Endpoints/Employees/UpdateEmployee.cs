using FastEndpoints;
using HazPro.HR.Model;
using HazPro.HR.Services;
using Microsoft.AspNetCore.Mvc;

namespace HazPro.HR.Endpoints.Employees;

public class UpdateEmployee : Endpoint<UpdateEmployeeRequest>
{
    private readonly IEmployeeServices _employeeServices;

    public UpdateEmployee(IEmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }

    public override void Configure()
    {
        Post("/api/hr/employees/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateEmployeeRequest req, CancellationToken ct)
    {
        if (req.Id != req.EmployeeDto.EmployeeId)
        {
            await Send.ResponseAsync("ID Mismatch", 400, ct);
            return;
        }
        
        var success = await _employeeServices.UpdateEmployeeAsync(req.EmployeeDto);
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

public record UpdateEmployeeRequest
{
    [FromRoute] public int Id { get; init; }
    [Microsoft.AspNetCore.Mvc.FromBody] public EmployeeDto EmployeeDto { get; init; }
}