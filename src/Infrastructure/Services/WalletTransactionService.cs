using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Blazor.Application.Features.Wallets.DTOs;
using CleanArchitecture.Blazor.Application.Features.WalletTransactions.DTOs;
using CleanArchitecture.Blazor.Domain.Entities;

namespace CleanArchitecture.Blazor.Infrastructure.Services;
public class WalletTransactionService : IWalletTransactionService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public WalletTransactionService(ApplicationDbContext context,
        IMapper mapper,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }   

    public void Save(WalletTransactionDto walletTransaction)
    {
        var item = _mapper.Map<WalletTransaction>(walletTransaction);
        if (walletTransaction.Id == 0)
        {
            _context.WalletTransactions.Add(item);
        }
        else
        {
            _context.WalletTransactions.Update(item);
        }
        _context.SaveChanges();
    }

    public void SaveWallet(WalletDto wallet)
    {
        var item = _mapper.Map<Wallet>(wallet);
        if (wallet.Id == 0)
        {
            _context.Wallets.Add(item);
        }
        else
        {
            _context.Wallets.Update(item);
        }
        _context.SaveChanges();
    }
}
