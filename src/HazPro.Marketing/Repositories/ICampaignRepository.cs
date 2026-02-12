using HazPro.Marketing.Model;

namespace HazPro.Marketing.Repositories;

public interface ICampaignRepository
{
    Task<Campaign> GetByIdAsync(int id);
    Task<Campaign> ListAllAsync();
    Task AddAsync(Campaign campaign);
    Task UpdateAsync(Campaign campaign);
    Task DeleteAsync(Campaign campaign);
    Task<int> SaveChangesAsync();
}