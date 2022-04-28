// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace CleanArchitecture.Blazor.Application.Features.Wallets.Caching;

public static class WalletCacheKey
{
    public const string GetAllCacheKey = "all-Wallets";
    public static string GetPagtionCacheKey(string parameters)
    {
        return "WalletsWithPaginationQuery,{parameters}";
    }
}

