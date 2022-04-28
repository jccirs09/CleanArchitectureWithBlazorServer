using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Blazor.Infrastructure.Services;
public class WalletTransactionService : IWalletTransactionService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public WalletTransactionService(IApplicationDbContext context,
        IMapper mapper,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<int> GetPendingPayoutCountAsync()
    {
        var userId = await _currentUserService.UserId();
        return await _context.WalletPayouts.CountAsync(u => u.CreatedBy == userId && u.Stat.Equals("Pending"));

    }
}
