using HazPro.Marketing.Model;

namespace HazPro.Marketing.Services;

public interface ICampaignService
{
    List<CampaignDto> ListCampaigns();
}