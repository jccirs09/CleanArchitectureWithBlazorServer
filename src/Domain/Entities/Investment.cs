namespace CleanArchitecture.Blazor.Domain.Entities;
public class Investment : AuditableEntity
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string? Stat { get; set; }
    public decimal DailyRate { get; set; }
    public bool IsActive { get; set; }
    public DateTime EndOfInvestment { get; set; }
    public string? ProofType { get; set; }
    public IList<string>? ImageDateUrl { get; set; }
}
