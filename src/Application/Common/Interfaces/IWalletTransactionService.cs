namespace CleanArchitecture.Blazor.Application.Common.Interfaces;
public interface IWalletTransactionService
{
    Task<int> GetPendingPayoutCountAsync();
}
