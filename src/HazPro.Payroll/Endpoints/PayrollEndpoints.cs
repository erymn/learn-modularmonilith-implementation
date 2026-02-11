using HazPro.Payroll.Services;
using Microsoft.AspNetCore.Builder;

namespace HazPro.Payroll.Endpoints;

internal static class PayrollEndpoints
{
    public static void MapPayrollEndpoints(this WebApplication app)
    {
        app.MapGet("/payroll/invoices", (InvoiceService invoiceService) =>
        {
            return invoiceService.ListInvoices();
        });
    }
}