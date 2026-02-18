using HazPro.HR.Model;
using HazPro.HR.Services;
using MediatR;

namespace HazPro.HR.Features.Employees;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IEmployeeServices _employeeServices;

    public DeleteEmployeeCommandHandler(IEmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }
    
    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await _employeeServices.DeleteEmployeeAsync(request.Id);
    }
}