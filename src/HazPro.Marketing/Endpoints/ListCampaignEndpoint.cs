using FastEndpoints;
using HazPro.Marketing.Model;
using HazPro.Marketing.Services;

namespace HazPro.Marketing.Endpoints;

public class ListCampaignEndpoint : EndpointWithoutRequest<List<CampaignDto>>
{
    private readonly ICampaignService _campaignService;

    public ListCampaignEndpoint(ICampaignService campaignService)
    {
        _campaignService = campaignService;
    }

    public override void Configure()
    {
        Get("/api/marketing/campaigns");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<CampaignDto> campaigns = _campaignService.ListCampaigns();
        await Send.OkAsync(campaigns);
    }
}