using HazPro.Payroll.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HazPro.Payroll.Extensions;

public static class PayrollServicesExtensions
{
    public static IServiceCollection AddPayrollServices(this IServiceCollection services)
    {
        services.AddScoped<IInvoiceService, InvoiceService>();
        return services;
    }
}