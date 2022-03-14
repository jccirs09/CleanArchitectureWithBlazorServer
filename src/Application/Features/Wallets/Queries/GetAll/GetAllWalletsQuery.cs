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

        public GetAllWalletsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<GetAllWalletsQueryHandler> localizer
            )
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<IEnumerable<WalletDto>> Handle(GetAllWalletsQuery request, CancellationToken cancellationToken)
        {
            //TODO:Implementing GetAllWalletsQueryHandler method 
            var data = await _context.Wallets
                         .ProjectTo<WalletDto>(_mapper.ConfigurationProvider)
                         .ToListAsync(cancellationToken);
            return data;
        }
    }


