// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using CleanArchitecture.Blazor.Application.Features.WalletTransactions.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.Commands.AddEdit;

public class AddEditWalletTransactionCommand : WalletTransactionDto, IRequest<Result<int>>, IMapFrom<WalletTransaction>
{

}

public class AddEditWalletTransactionCommandHandler : IRequestHandler<AddEditWalletTransactionCommand, Result<int>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<AddEditWalletTransactionCommandHandler> _localizer;
    public AddEditWalletTransactionCommandHandler(
        IApplicationDbContext context,
        IStringLocalizer<AddEditWalletTransactionCommandHandler> localizer,
        IMapper mapper
        )
    {
        _context = context;
        _localizer = localizer;
        _mapper = mapper;
    }
    public async Task<Result<int>> Handle(AddEditWalletTransactionCommand request, CancellationToken cancellationToken)
    {
        //TODO:Implementing AddEditWalletTransactionCommandHandler method 
        if (request.Id > 0)
        {
            var item = await _context.WalletTransactions.FindAsync(new object[] { request.Id }, cancellationToken);
            _ = item ?? throw new NotFoundException($"Transaction {request.Id} Not Found.");
            item = _mapper.Map(request, item);
            await _context.SaveChangesAsync(cancellationToken);
            return Result<int>.Success(item.Id);
        }
        else
        {
            var item = _mapper.Map<WalletTransaction>(request);
            _context.WalletTransactions.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
            return Result<int>.Success(item.Id);
        }

    }
}

