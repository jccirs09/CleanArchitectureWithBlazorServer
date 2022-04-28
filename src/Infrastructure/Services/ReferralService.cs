using AutoMapper;
using CleanArchitecture.Blazor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Blazor.Infrastructure.Services;
public class ReferralService : IReferralService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public ReferralService(IApplicationDbContext context,
        IMapper mapper,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }
    public async Task<Referral> GetReferralAsync(string referralId)
    {
        return await _context.Referrals.FirstOrDefaultAsync(x => x.ReferralCode == referralId);
    }

    public async Task<decimal> GetInvestorWalletAsync()
    {
        var userId = await _currentUserService.UserId();
        return await _context.Wallets.Where(u => u.CreatedBy.Equals(userId)).SumAsync(x => x.CurrentBalance);
    }

    public async Task<int> GetInvestorInvestmentCountAsync()
    {
        var userId = await _currentUserService.UserId();
        return await _context.Investments.CountAsync(u => u.CreatedBy == userId && u.IsActive == true);

    }

    public async Task<decimal> GetInvestorInvestmentSumAsync()
    {
        var userId = await _currentUserService.UserId();
        return await _context.Investments.Where(a => a.CreatedBy == userId && a.IsActive == true).SumAsync(u => u.Amount);
    }

    public async Task<decimal> GetInvestorInvestmentDailyRateAsync()
    {
        var userId = await _currentUserService.UserId();
        return await _context.Investments.Where(a => a.CreatedBy == userId && a.IsActive == true).SumAsync(u => u.DailyRate);
    }

    public async Task<Wallet> GetWalletUser(string userId)
    {
        return await _context.Wallets.FirstOrDefaultAsync(x => x.CreatedBy.Equals(userId));
    }

    public async Task<Referral> GetReferralCodeAsync(string userId)
    {
        return await _context.Referrals.FirstOrDefaultAsync(x => x.UserId == userId);
    }
}
