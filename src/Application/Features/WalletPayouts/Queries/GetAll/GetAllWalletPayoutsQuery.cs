// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.WalletPayouts.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletPayouts.Queries.GetAll;

public class GetAllWalletPayoutsQuery : IRequest<IEnumerable<WalletPayoutDto>>
{

}

public class GetAllWalletPayoutsQueryHandler :
     IRequestHandler<GetAllWalletPayoutsQuery, IEnumerable<WalletPayoutDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<GetAllWalletPayoutsQueryHandler> _localizer;
    private readonly ICurrentUserService _userService;

    public GetAllWalletPayoutsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<GetAllWalletPayoutsQueryHandler> localizer,
            ICurrentUserService userService)
    {
        _userService = userService;
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<IEnumerable<WalletPayoutDto>> Handle(GetAllWalletPayoutsQuery request, CancellationToken cancellationToken)
    {
        //TODO:Implementing GetAllWalletPayoutsQueryHandler method
        var userId = await _userService.UserId();
        var data = await _context.WalletPayouts.Where(u => u.FromUser.Equals(userId))
                         .OrderByDescending(s => s.Stat)
                         .ThenByDescending(d => d.Created)
                         .ProjectTo<WalletPayoutDto>(_mapper.ConfigurationProvider)
                         .ToListAsync(cancellationToken);
        return data;
    }
}


