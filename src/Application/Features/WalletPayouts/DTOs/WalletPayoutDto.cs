// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.WalletPayouts.DTOs;


public class WalletPayoutDto : IMapFrom<WalletPayout>
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public decimal Amount { get; set; }
    public string? FromUser { get; set; }
    public string? ToUser { get; set; }
    public string? Stat { get; set; }
    public DateTime Created { get; set; }
}

