// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Investments.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Investments.Queries.GetAll;

    public class GetAllInvestmentsQuery : IRequest<IEnumerable<InvestmentDto>>
    {
       
    }
    
    public class GetAllInvestmentsQueryHandler :
         IRequestHandler<GetAllInvestmentsQuery, IEnumerable<InvestmentDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<GetAllInvestmentsQueryHandler> _localizer;
    private readonly ICurrentUserService _currentUserService;

    public GetAllInvestmentsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<GetAllInvestmentsQueryHandler> localizer,
            ICurrentUserService currentUserService
            )
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
        _currentUserService = currentUserService;
    }

        public async Task<IEnumerable<InvestmentDto>> Handle(GetAllInvestmentsQuery request, CancellationToken cancellationToken)
        {
        var userId = await _currentUserService.UserId();
            //TODO:Implementing GetAllInvestmentsQueryHandler method 
            var data = await _context.Investments
                    .Where(x=>x.CreatedBy.Equals(userId))
                    .OrderByDescending(o => o.Created)
                    .ProjectTo<InvestmentDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            return data;
        }
    }


