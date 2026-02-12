using HazPro.Marketing.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HazPro.Marketing.Extensions;

public static class MarketingServicesExtensions
{
    public static IServiceCollection AddMarketingServices(this IServiceCollection services)
    {
        services.AddScoped<ICampaignService, CampaignService>();
        return services;
    }
}