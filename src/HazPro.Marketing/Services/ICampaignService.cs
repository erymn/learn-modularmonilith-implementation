using HazPro.Marketing.Model;

namespace HazPro.Marketing.Services;

internal interface ICampaignService
{
    List<CampaignDto> ListCampaigns();
}