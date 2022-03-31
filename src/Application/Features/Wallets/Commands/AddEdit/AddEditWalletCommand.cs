// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using CleanArchitecture.Blazor.Application.Features.Wallets.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Wallets.Commands.AddEdit;

    public class AddEditWalletCommand: WalletDto,IRequest<Result<int>>, IMapFrom<Wallet>
    {
      
    }

    public class AddEditWalletCommandHandler : IRequestHandler<AddEditWalletCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditWalletCommandHandler> _localizer;
        public AddEditWalletCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<AddEditWalletCommandHandler> localizer,
            IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(AddEditWalletCommand request, CancellationToken cancellationToken)
        {
            //TODO:Implementing AddEditWalletCommandHandler method 
            if (request.Id > 0)
            {
            var item = await _context.Wallets.FindAsync(new object[] { request.Id }, cancellationToken);
            _ = item ?? throw new NotFoundException($"Wallet {request.Id} Not Found.");
            item = _mapper.Map(request, item);
            await _context.SaveChangesAsync(cancellationToken);
            return Result<int>.Success(item.Id);
        }
            else
            {
                var item = _mapper.Map<Wallet>(request);
                _context.Wallets.Add(item);
                await _context.SaveChangesAsync(cancellationToken);
                return Result<int>.Success(item.Id);
            }
           
        }
    }

