using HazPro.HR.Data;
using HazPro.HR.Repositories;
using HazPro.HR.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HazPro.HR.Extensions;

public static class HRServicesExtensions
{
    public static IServiceCollection AddHRServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IEmployeeServices, EmployeeServices>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        //services.AddScoped<IEmployeeRepository>();
        
        //register database service
        var connectionString = configuration.GetConnectionString("HazProHRConnection");
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

        services.AddMediatR(typeof(HRServicesExtensions).Assembly);
        
        return services;
    }
}