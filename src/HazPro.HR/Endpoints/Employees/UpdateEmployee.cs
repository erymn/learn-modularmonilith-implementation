using FastEndpoints;
using HazPro.HR.Features.Employees;
using HazPro.HR.Model;
using HazPro.HR.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HazPro.HR.Endpoints.Employees;

public class UpdateEmployee : Endpoint<UpdateEmployeeRequest>
{
    private readonly IMediator _mediator;
    
    public UpdateEmployee(IMediator mediator)
    {
        _mediator = mediator;
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

        var command = new UpdateEmployeeCommand(req.Id, req.EmployeeDto);
        var result = await _mediator.Send(command, ct);

        if (result)
            await Send.NoContentAsync(ct);
        else
            await Send.NotFoundAsync(ct);
    }
}

public record UpdateEmployeeRequest
{
    [FromRoute] public int Id { get; init; }
    [Microsoft.AspNetCore.Mvc.FromBody] public EmployeeDto EmployeeDto { get; init; }
}