// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.WalletTransactions.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.Queries.Pagination;

public class WalletTransactionsWithPaginationQuery : PaginationFilter, IRequest<PaginatedData<WalletTransactionDto>>
{

}

public class WalletTransactionsWithPaginationQueryHandler :
     IRequestHandler<WalletTransactionsWithPaginationQuery, PaginatedData<WalletTransactionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<WalletTransactionsWithPaginationQueryHandler> _localizer;

    public WalletTransactionsWithPaginationQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        IStringLocalizer<WalletTransactionsWithPaginationQueryHandler> localizer
        )
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<PaginatedData<WalletTransactionDto>> Handle(WalletTransactionsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        //TODO:Implementing WalletTransactionsWithPaginationQueryHandler method 
        var data = await _context.WalletTransactions
         .OrderBy($"{request.OrderBy} {request.SortDirection}")
         .ProjectTo<WalletTransactionDto>(_mapper.ConfigurationProvider)
         .PaginatedDataAsync(request.PageNumber, request.PageSize);
        return data;
    }
}