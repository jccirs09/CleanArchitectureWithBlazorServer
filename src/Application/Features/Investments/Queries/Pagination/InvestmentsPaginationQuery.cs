// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Investments.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Investments.Queries.Pagination;

    public class InvestmentsWithPaginationQuery : PaginationRequest, IRequest<PaginatedData<InvestmentDto>>
    {
       
    }
    
    public class InvestmentsWithPaginationQueryHandler :
         IRequestHandler<InvestmentsWithPaginationQuery, PaginatedData<InvestmentDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<InvestmentsWithPaginationQueryHandler> _localizer;

        public InvestmentsWithPaginationQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<InvestmentsWithPaginationQueryHandler> localizer
            )
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<PaginatedData<InvestmentDto>> Handle(InvestmentsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            //TODO:Implementing InvestmentsWithPaginationQueryHandler method 
           var filters = PredicateBuilder.FromFilter<Investment>(request.FilterRules);
           var data = await _context.Investments.Where(filters)
                .OrderBy("{request.Sort} {request.Order}")
                .ProjectTo<InvestmentDto>(_mapper.ConfigurationProvider)
                .PaginatedDataAsync(request.Page, request.Rows);
            return data;
        }
   }