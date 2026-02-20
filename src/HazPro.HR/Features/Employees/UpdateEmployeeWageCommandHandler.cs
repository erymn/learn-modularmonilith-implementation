using Ardalis.Result;
using HazPro.HR.Services;
using MediatR;

namespace HazPro.HR.Features.Employees;

public class UpdateEmployeeWageCommandHandler : IRequestHandler<UpdateEmployeeWageCommand, Result<bool>>
{
    private readonly IEmployeeServices _employeeServices;

    public UpdateEmployeeWageCommandHandler(IEmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }
    
    public async Task<Result<bool>> Handle(UpdateEmployeeWageCommand request, CancellationToken cancellationToken)
    {
        return await _employeeServices.UpdateEmployeeWageAsync(request.Id, request.NewHourlyWage);
    }
}