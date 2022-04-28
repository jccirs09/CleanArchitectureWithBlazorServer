// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Wallets.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Wallets.Commands.Update;

public class UpdateWalletCommand : WalletDto, IRequest<Result>, IMapFrom<Wallet>
{

}

public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<UpdateWalletCommandHandler> _localizer;
    public UpdateWalletCommandHandler(
        IApplicationDbContext context,
        IStringLocalizer<UpdateWalletCommandHandler> localizer,
         IMapper mapper
        )
    {
        _context = context;
        _localizer = localizer;
        _mapper = mapper;
    }
    public async Task<Result> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
    {
        //TODO:Implementing UpdateWalletCommandHandler method 
        var item = await _context.Wallets.FindAsync(new object[] { request.Id }, cancellationToken);
        if (item != null)
        {
            item = _mapper.Map(request, item);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Result.Success();
    }
}

