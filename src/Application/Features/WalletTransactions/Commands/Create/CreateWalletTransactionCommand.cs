// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.WalletTransactions.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.Commands.Create;

    public class CreateWalletTransactionCommand: WalletTransactionDto,IRequest<Result<int>>, IMapFrom<WalletTransaction>
    {
       
    }
    
    public class CreateWalletTransactionCommandHandler : IRequestHandler<CreateWalletTransactionCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CreateWalletTransactionCommand> _localizer;
        public CreateWalletTransactionCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<CreateWalletTransactionCommand> localizer,
            IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateWalletTransactionCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing CreateWalletTransactionCommandHandler method 
           var item = _mapper.Map<WalletTransaction>(request);
           _context.WalletTransactions.Add(item);
           await _context.SaveChangesAsync(cancellationToken);
           return  Result<int>.Success(item.Id);
        }
    }

