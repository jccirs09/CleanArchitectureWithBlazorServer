// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Wallets.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Wallets.Queries.GetAll;

    public class GetAllWalletsQuery : IRequest<IEnumerable<WalletDto>>
    {
       
    }
    
    public class GetAllWalletsQueryHandler :
         IRequestHandler<GetAllWalletsQuery, IEnumerable<WalletDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<GetAllWalletsQueryHandler> _localizer;
    private readonly ICurrentUserService _userService;

    public GetAllWalletsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<GetAllWalletsQueryHandler> localizer,
            ICurrentUserService userService
            )
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
        _userService = userService;
    }

        public async Task<IEnumerable<WalletDto>> Handle(GetAllWalletsQuery request, CancellationToken cancellationToken)
        {
            //TODO:Implementing GetAllWalletsQueryHandler method
            var userId = await _userService.UserId();
            var data = await _context.Wallets
            .Where(x=> x.CreatedBy.Equals(userId))
                         .ProjectTo<WalletDto>(_mapper.ConfigurationProvider)
                         .ToListAsync(cancellationToken);
            return data;
        }
    }


