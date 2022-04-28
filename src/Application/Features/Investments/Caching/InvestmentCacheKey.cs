// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace CleanArchitecture.Blazor.Application.Features.Investments.Caching;

public static class InvestmentCacheKey
{
    public const string GetAllCacheKey = "all-Investments";
    public static string GetPagtionCacheKey(string parameters)
    {
        return "InvestmentsWithPaginationQuery,{parameters}";
    }
}

