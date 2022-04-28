// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.Caching;

public static class WalletTransactionCacheKey
{
    public const string GetAllCacheKey = "all-WalletTransactions";
    public static string GetPagtionCacheKey(string parameters)
    {
        return "WalletTransactionsWithPaginationQuery,{parameters}";
    }
}

