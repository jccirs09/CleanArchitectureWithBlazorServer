// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Wallets.DTOs;


public class WalletDto : IMapFrom<Wallet>
{
    public int Id { get; set; }
    public decimal CurrentBalance { get; set; }
    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }


}

