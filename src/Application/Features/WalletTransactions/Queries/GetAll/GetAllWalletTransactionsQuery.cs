// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.WalletTransactions.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.Queries.GetAll;

public class GetAllWalletTransactionsQuery : IRequest<IEnumerable<WalletTransactionDto>>
{

}

public class GetAllWalletTransactionsQueryHandler :
     IRequestHandler<GetAllWalletTransactionsQuery, IEnumerable<WalletTransactionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<GetAllWalletTransactionsQueryHandler> _localizer;
    private readonly ICurrentUserService _currentUserService;

    public GetAllWalletTransactionsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<GetAllWalletTransactionsQueryHandler> localizer,
            ICurrentUserService currentUserService
            )
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
        _currentUserService = currentUserService;
    }

    public async Task<IEnumerable<WalletTransactionDto>> Handle(GetAllWalletTransactionsQuery request, CancellationToken cancellationToken)
    {
        //TODO:Implementing GetAllWalletTransactionsQueryHandler method
        var userId = await _currentUserService.UserId();
        var data = await _context.WalletTransactions
                    .Where(u => u.UserId.Equals(userId))
                    .OrderByDescending(o => o.Id)
                    .ProjectTo<WalletTransactionDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
        return data;
    }
}


