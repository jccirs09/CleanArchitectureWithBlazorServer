using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Blazor.Application.Features.Investments.DTOs;

namespace CleanArchitecture.Blazor.Application.Common.Interfaces;
public  interface IReferralService
{
    Task <Referral> GetReferralAsync (string referralId);
    Task<Wallet> GetWalletUser(string userId);
    Task <decimal> GetInvestorWalletAsync();
    Task <int> GetInvestorInvestmentCountAsync();
    Task<decimal> GetInvestorInvestmentSumAsync();
    Task<decimal> GetInvestorInvestmentDailyRateAsync();
}
