using HazPro.Payroll.Model;

namespace HazPro.Payroll.Services;

internal class InvoiceService : IInvoiceService
{
    public List<InvoiceDto> ListInvoices()
    {
        return new List<InvoiceDto>()
        {
            new InvoiceDto(1, 20000000, DateTime.Now, "Pending"),
            new InvoiceDto(2, 19000000, DateTime.Now, "Complete"),
            new InvoiceDto(3, 15000000, DateTime.Now, "Pending")
        };
    }
}