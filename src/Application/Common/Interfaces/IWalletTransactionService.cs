using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Blazor.Application.Features.Wallets.DTOs;
using CleanArchitecture.Blazor.Application.Features.WalletTransactions.DTOs;

namespace CleanArchitecture.Blazor.Application.Common.Interfaces;
public interface IWalletTransactionService
{
    void Save (WalletTransactionDto walletTransaction);
    void SaveWallet (WalletDto wallet);
}
