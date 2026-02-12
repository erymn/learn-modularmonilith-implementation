using HazPro.Payroll.Model;

namespace HazPro.Payroll.Services;

internal interface IInvoiceService
{
    List<InvoiceDto> ListInvoices();
}