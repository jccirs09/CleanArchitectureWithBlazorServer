namespace CleanArchitecture.Blazor.Domain.Entities;
public class Referral
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public string? ReferralCode { get; set; }
    public string? ReferredBy { get; set; }
}
