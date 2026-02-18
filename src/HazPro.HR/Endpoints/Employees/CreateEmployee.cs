using FastEndpoints;
using HazPro.HR.Features.Employees;
using HazPro.HR.Model;
using HazPro.HR.Services;
using MediatR;

namespace HazPro.HR.Endpoints.Employees;

public class CreateEmployee : Endpoint<EmployeeDto, CreatedEmployeeResponse>
{
    private readonly IMediator _mediator;

    public CreateEmployee(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("/api/hr/employees");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmployeeDto req, CancellationToken ct)
    {
        // var created = await _employeesevice.AddEmployeeAsync(req);
        //
        // await Send.CreatedAtAsync<GetEmployeeById>(
        //     new { id = created.EmployeeId }
        //     , new CreatedEmployeeResponse(created.EmployeeId)
        //     , generateAbsoluteUrl: false
        //     , cancellation: ct
        // );
        var command = new CreateEmployeeCommand(req);
        var employee = await _mediator.Send(command, ct);
        await Send.CreatedAtAsync<GetEmployeeById>(
            new { id = employee.EmployeeId }
            , new CreatedEmployeeResponse(employee.EmployeeId)
            , generateAbsoluteUrl: false
            , cancellation: ct
        );
    }
}

public record CreatedEmployeeResponse(int EmployeeId);