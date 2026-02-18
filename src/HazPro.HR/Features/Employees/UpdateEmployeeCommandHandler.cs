using HazPro.HR.Services;
using MediatR;

namespace HazPro.HR.Features.Employees;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IEmployeeServices _employeeServices;

    public UpdateEmployeeCommandHandler(IEmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }
    
    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        // if (request.Id != request.EmployeeDto.EmployeeId)
        // {
        //     return false;
        // }
        
        var result = await _employeeServices.UpdateEmployeeAsync(request.EmployeeDto);
        return result;
    }
}