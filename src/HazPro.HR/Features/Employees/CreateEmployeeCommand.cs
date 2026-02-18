using HazPro.HR.Model;
using MediatR;

namespace HazPro.HR.Features.Employees;

public record CreateEmployeeCommand(EmployeeDto EmployeeDto) : IRequest<EmployeeDto>;