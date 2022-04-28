namespace CleanArchitecture.Blazor.Application.Common.Interfaces;
public interface IReferralService
{
    Task<Referral> GetReferralAsync(string referralId);
    Task<Referral> GetReferralCodeAsync(string userId);
    Task<Wallet> GetWalletUser(string userId);
    Task<decimal> GetInvestorWalletAsync();
    Task<int> GetInvestorInvestmentCountAsync();
    Task<decimal> GetInvestorInvestmentSumAsync();
    Task<decimal> GetInvestorInvestmentDailyRateAsync();
}
