using HazPro.HR.Model;
using MediatR;

namespace HazPro.HR.Features.Employees;

public record DeleteEmployeeCommand(int Id) : IRequest<bool>;