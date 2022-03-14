// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Wallets.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Wallets.Commands.Create;

    public class CreateWalletCommand: WalletDto,IRequest<Result<int>>, IMapFrom<Wallet>
    {
       
    }
    
    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CreateWalletCommand> _localizer;
        public CreateWalletCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<CreateWalletCommand> localizer,
            IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing CreateWalletCommandHandler method 
           var item = _mapper.Map<Wallet>(request);
           _context.Wallets.Add(item);
           await _context.SaveChangesAsync(cancellationToken);
           return  Result<int>.Success(item.Id);
        }
    }

