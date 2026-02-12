using HazPro.Marketing.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace HazPro.Marketing.Endpoints;

public static class MarketingEndpoints
{
    public static void MapMarketingEndpoints(this WebApplication app)
    {
        app.MapGet("/marketing/campaigns", ([FromServices] ICampaignService campaignService) =>
        {
            return campaignService.ListCampaigns();
        });
    }
}