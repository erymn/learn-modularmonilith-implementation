namespace HazPro.Payroll.Model;

public record InvoiceDto(int InvoiceId, decimal Amount, DateTime DateIssued, string Status);