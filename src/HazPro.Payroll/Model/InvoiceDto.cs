namespace HazPro.Payroll.Model;

internal record InvoiceDto(int InvoiceId, decimal Amount, DateTime DateIssued, string Status);