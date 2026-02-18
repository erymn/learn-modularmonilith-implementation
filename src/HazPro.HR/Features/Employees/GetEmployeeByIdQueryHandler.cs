using HazPro.HR.Model;
using HazPro.HR.Repositories;
using HazPro.HR.Services;
using MediatR;

namespace HazPro.HR.Features.Employees;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly IEmployeeServices _employeeServices;

    public GetEmployeeByIdQueryHandler(IEmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }
    
    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _employeeServices.GetEmployeeByIdAsync(request.Id);
    }
}