using HazPro.HR.Model;
using HazPro.HR.Services;
using MediatR;

namespace HazPro.HR.Features.Employees;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
{
    private readonly IEmployeeServices _employeesServices;

    public CreateEmployeeCommandHandler(IEmployeeServices  employeesServices)
    {
        _employeesServices = employeesServices;
    }
    
    public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await _employeesServices.AddEmployeeAsync(request.EmployeeDto);
    }
}