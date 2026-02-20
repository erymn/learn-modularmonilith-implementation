using Ardalis.Result;
using FastEndpoints;
using HazPro.HR.Features.Employees;
using MediatR;

namespace HazPro.HR.Endpoints.Employees;

public class UpdateEmployeeHourlyWageRequest
{
    [BindFrom("id")]
    public int EmployeeId { get; set; }

    public decimal NewHourlyWage { get; set; }
}

public class UpdateEmployeeHourlyWage : Endpoint<UpdateEmployeeHourlyWageRequest>
{
    private readonly IMediator _mediator;

    public UpdateEmployeeHourlyWage(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Put("/api/hr/employees/{id:int}/wage");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateEmployeeHourlyWageRequest req, CancellationToken ct)
    {
        var command = new UpdateEmployeeWageCommand(req.EmployeeId, req.NewHourlyWage);
        var result = await _mediator.Send(command, ct);
        
        if (result.IsSuccess && result.Value)
            await Send.NoContentAsync(ct);
        else if (result.Status == ResultStatus.NotFound)
            await Send.NotFoundAsync(ct);
        else
            await Send.ResponseAsync(result.Errors,400, ct);
    }
}