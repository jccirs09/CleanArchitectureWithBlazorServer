// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.WalletPayouts.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletPayouts.Queries.Pagination;

    public class WalletPayoutsWithPaginationQuery : PaginationRequest, IRequest<PaginatedData<WalletPayoutDto>>
    {
       
    }
    
    public class WalletPayoutsWithPaginationQueryHandler :
         IRequestHandler<WalletPayoutsWithPaginationQuery, PaginatedData<WalletPayoutDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<WalletPayoutsWithPaginationQueryHandler> _localizer;

        public WalletPayoutsWithPaginationQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<WalletPayoutsWithPaginationQueryHandler> localizer
            )
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<PaginatedData<WalletPayoutDto>> Handle(WalletPayoutsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            //TODO:Implementing WalletPayoutsWithPaginationQueryHandler method 
           var filters = PredicateBuilder.FromFilter<WalletPayout>(request.FilterRules);
           var data = await _context.WalletPayouts.Where(filters)
                .OrderBy("{request.Sort} {request.Order}")
                .ProjectTo<WalletPayoutDto>(_mapper.ConfigurationProvider)
                .PaginatedDataAsync(request.Page, request.Rows);
            return data;
        }
   }