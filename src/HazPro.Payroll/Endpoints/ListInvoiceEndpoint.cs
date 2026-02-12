using FastEndpoints;
using HazPro.Payroll.Model;
using HazPro.Payroll.Services;

namespace HazPro.Payroll.Endpoints;

public class ListInvoiceEndpoint : EndpointWithoutRequest<List<InvoiceDto>>
{
    private readonly IInvoiceService _invoiceService;

    public ListInvoiceEndpoint(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    public override void Configure()
    {
        Get("/api/payroll/invoices");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<InvoiceDto> invoices = _invoiceService.ListInvoices();
        await Send.OkAsync(invoices);
    }
}