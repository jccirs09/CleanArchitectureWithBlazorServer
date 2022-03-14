// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Wallets.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Wallets.Queries.Pagination;

    public class WalletsWithPaginationQuery : PaginationRequest, IRequest<PaginatedData<WalletDto>>
    {
       
    }
    
    public class WalletsWithPaginationQueryHandler :
         IRequestHandler<WalletsWithPaginationQuery, PaginatedData<WalletDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<WalletsWithPaginationQueryHandler> _localizer;

        public WalletsWithPaginationQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<WalletsWithPaginationQueryHandler> localizer
            )
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<PaginatedData<WalletDto>> Handle(WalletsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            //TODO:Implementing WalletsWithPaginationQueryHandler method 
           var filters = PredicateBuilder.FromFilter<Wallet>(request.FilterRules);
           var data = await _context.Wallets.Where(filters)
                .OrderBy("{request.Sort} {request.Order}")
                .ProjectTo<WalletDto>(_mapper.ConfigurationProvider)
                .PaginatedDataAsync(request.Page, request.Rows);
            return data;
        }
   }