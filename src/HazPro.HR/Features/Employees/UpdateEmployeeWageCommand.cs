using Ardalis.Result;
using MediatR;

namespace HazPro.HR.Features.Employees;

public record UpdateEmployeeWageCommand(int Id, decimal NewHourlyWage) : IRequest<Result<bool>>;