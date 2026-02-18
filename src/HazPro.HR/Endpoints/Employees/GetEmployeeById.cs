using FastEndpoints;
using HazPro.HR.Features.Employees;
using HazPro.HR.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HazPro.HR.Endpoints.Employees;

public class GetEmployeeById : Endpoint<GetEmployeeByIdRequest>
{
    // private readonly IEmployeeServices _employeeServices;
    //
    // public GetEmployeeById(IEmployeeServices employeeServices)
    // {
    //     _employeeServices = employeeServices;
    // }

    private readonly IMediator _mediator;
    public GetEmployeeById(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("/api/hr/employees/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetEmployeeByIdRequest req, CancellationToken ct)
    {
        // var employee = await _employeeServices.GetEmployeeByIdAsync(req.Id);
        // if (employee == null)
        // {
        //     await Send.NotFoundAsync(ct);
        //     return;
        // }
        // else
        // {
        //     await Send.OkAsync(employee, ct);
        // }
        
        var query = new GetEmployeeByIdQuery(req.Id);
        var employee = await _mediator.Send(query, ct);
        if (employee == null)
            await Send.NotFoundAsync(ct);
        else
            await Send.OkAsync(employee, ct);
    }
}

public record GetEmployeeByIdRequest()
{
    [FromRoute] public int Id { get; init; }
}
