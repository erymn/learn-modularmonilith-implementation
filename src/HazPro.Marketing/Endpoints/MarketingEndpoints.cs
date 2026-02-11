using HazPro.Marketing.Services;
using Microsoft.AspNetCore.Builder;

namespace HazPro.Marketing.Endpoints;

internal static class MarketingEndpoints
{
    public static void MapMarketingEndpoints(this WebApplication app)
    {
        app.MapGet("/marketing/campaigns", (CampaignService campaignService) =>
        {
            return campaignService.ListCampaigns();
        });
    }
}