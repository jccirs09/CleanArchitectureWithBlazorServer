// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Investments.DTOs;


public class InvestmentDto : IMapFrom<Investment>
{

    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string? Stat { get; set; }
    public decimal DailyRate { get; set; }
    public bool IsActive { get; set; }
    public DateTime EndOfInvestment { get; set; }
    public string? ProofType { get; set; }
    public IList<string>? ImageDateUrl { get; set; }
    public string CreatedBy { get; set; }
    public DateTime Created { get; set; }
}

