using FastEndpoints;
using HazPro.HR.Features.Employees;
using HazPro.HR.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HazPro.HR.Endpoints.Employees;

public class DeleteEmployee : Endpoint<DeleteEmployeeRequest>
{
    private readonly IMediator _mediator;

    public DeleteEmployee(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Delete("/api/hr/employees/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteEmployeeRequest req, CancellationToken ct)
    {
        var command = new DeleteEmployeeCommand(req.Id);
        var result = await _mediator.Send(command, ct);
        
        //var success = await _employeeServices.DeleteEmployeeAsync(req.Id);
        if (!result)
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