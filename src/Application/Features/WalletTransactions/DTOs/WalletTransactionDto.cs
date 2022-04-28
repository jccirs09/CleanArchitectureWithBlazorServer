// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.DTOs;


public class WalletTransactionDto : IMapFrom<WalletTransaction>
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public decimal Amount { get; set; }
    public decimal PreviousBalance { get; set; }
    public decimal NewBalance { get; set; }
    public string? Stat { get; set; }
    public string? Type { get; set; }
    public int? InvestmentId { get; set; }
    public int? PayoutId { get; set; }
    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}

