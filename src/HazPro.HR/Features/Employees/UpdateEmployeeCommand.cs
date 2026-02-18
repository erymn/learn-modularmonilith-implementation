using HazPro.HR.Model;
using MediatR;

namespace HazPro.HR.Features.Employees;

public record UpdateEmployeeCommand(int Id, EmployeeDto EmployeeDto) : IRequest<bool>;