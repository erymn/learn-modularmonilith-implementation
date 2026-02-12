using HazPro.Payroll.Model;

namespace HazPro.Payroll.Services;

public interface IInvoiceService
{
    List<InvoiceDto> ListInvoices();
}