// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.WalletPayouts.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletPayouts.Commands.Create;

public class CreateWalletPayoutCommand : WalletPayoutDto, IRequest<Result<int>>, IMapFrom<WalletPayout>
{

}

public class CreateWalletPayoutCommandHandler : IRequestHandler<CreateWalletPayoutCommand, Result<int>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<CreateWalletPayoutCommand> _localizer;
    public CreateWalletPayoutCommandHandler(
        IApplicationDbContext context,
        IStringLocalizer<CreateWalletPayoutCommand> localizer,
        IMapper mapper
        )
    {
        _context = context;
        _localizer = localizer;
        _mapper = mapper;
    }
    public async Task<Result<int>> Handle(CreateWalletPayoutCommand request, CancellationToken cancellationToken)
    {
        //TODO:Implementing CreateWalletPayoutCommandHandler method 
        var item = _mapper.Map<WalletPayout>(request);
        _context.WalletPayouts.Add(item);
        await _context.SaveChangesAsync(cancellationToken);
        return Result<int>.Success(item.Id);
    }
}

