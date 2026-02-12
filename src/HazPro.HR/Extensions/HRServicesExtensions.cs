using HazPro.HR.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HazPro.HR.Extensions;

public static class HRServicesExtensions
{
    public static IServiceCollection AddHRServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeServices, EmployeeServices>();
        return services;
    }
}