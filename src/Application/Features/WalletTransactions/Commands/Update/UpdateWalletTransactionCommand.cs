// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.WalletTransactions.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.Commands.Update;

public class UpdateWalletTransactionCommand : WalletTransactionDto, IRequest<Result>, IMapFrom<WalletTransaction>
{

}

public class UpdateWalletTransactionCommandHandler : IRequestHandler<UpdateWalletTransactionCommand, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<UpdateWalletTransactionCommandHandler> _localizer;
    public UpdateWalletTransactionCommandHandler(
        IApplicationDbContext context,
        IStringLocalizer<UpdateWalletTransactionCommandHandler> localizer,
         IMapper mapper
        )
    {
        _context = context;
        _localizer = localizer;
        _mapper = mapper;
    }
    public async Task<Result> Handle(UpdateWalletTransactionCommand request, CancellationToken cancellationToken)
    {
        //TODO:Implementing UpdateWalletTransactionCommandHandler method 
        var item = await _context.WalletTransactions.FindAsync(new object[] { request.Id }, cancellationToken);
        if (item != null)
        {
            item = _mapper.Map(request, item);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Result.Success();
    }
}

