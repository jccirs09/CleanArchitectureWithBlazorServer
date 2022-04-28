// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.



using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CleanArchitecture.Blazor.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Logger> Loggers { get; set; }
    DbSet<AuditTrail> AuditTrails { get; set; }
    DbSet<DocumentType> DocumentTypes { get; set; }
    DbSet<Document> Documents { get; set; }
    DbSet<KeyValue> KeyValues { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Investment> Investments { get; set; }
    DbSet<Wallet> Wallets { get; set; }
    DbSet<Referral> Referrals { get; set; }
    DbSet<WalletPayout> WalletPayouts { get; set; }
    DbSet<WalletTransaction> WalletTransactions { get; set; }
    ChangeTracker ChangeTracker { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
