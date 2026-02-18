using FastEndpoints;
using HazPro.HR.Model;
using HazPro.HR.Services;

namespace HazPro.HR.Endpoints.Employees;

public class CreateEmployee : Endpoint<EmployeeDto, CreatedEmployeeResponse>
{
    private readonly IEmployeeServices _employeesevice;

    public CreateEmployee(IEmployeeServices employeesevice)
    {
        _employeesevice = employeesevice;
    }

    public override void Configure()
    {
        Post("/api/hr/employees");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmployeeDto req, CancellationToken ct)
    {
        var created = await _employeesevice.AddEmployeeAsync(req);

        await Send.CreatedAtAsync<GetEmployeeById>(
            new { id = created.EmployeeId }
            , new CreatedEmployeeResponse(created.EmployeeId)
            , generateAbsoluteUrl: false
            , cancellation: ct
        );
    }
}

public record CreatedEmployeeResponse(int EmployeeId);