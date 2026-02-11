namespace HazPro.Payroll.Model;

public class Campaign
{
    public int CompaignId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public decimal Budget { get; set; }
    public string TargetAudience { get; set; }
}