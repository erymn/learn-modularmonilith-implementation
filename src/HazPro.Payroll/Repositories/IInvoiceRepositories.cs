using HazPro.Payroll.Model;

namespace HazPro.Payroll.Repositories;

public interface IInvoiceRepositories
{
    Task<Invoice> GetByIdAsync(int id);
    Task<Invoice> ListAllAsync();
    Task AddAsync(Invoice invoice);
    Task UpdateAsync(Invoice invoice);
    Task DeleteAsync(Invoice invoice);
    Task<int> SaveChangesAsync();
}