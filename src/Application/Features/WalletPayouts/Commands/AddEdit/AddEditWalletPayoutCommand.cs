// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using CleanArchitecture.Blazor.Application.Features.WalletPayouts.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletPayouts.Commands.AddEdit;

    public class AddEditWalletPayoutCommand: WalletPayoutDto,IRequest<Result<int>>, IMapFrom<WalletPayout>
    {
      
    }

    public class AddEditWalletPayoutCommandHandler : IRequestHandler<AddEditWalletPayoutCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditWalletPayoutCommandHandler> _localizer;
        public AddEditWalletPayoutCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<AddEditWalletPayoutCommandHandler> localizer,
            IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(AddEditWalletPayoutCommand request, CancellationToken cancellationToken)
        {
            //TODO:Implementing AddEditWalletPayoutCommandHandler method 
            if (request.Id > 0)
            {
            var item = await _context.WalletPayouts.FindAsync(new object[] { request.Id }, cancellationToken);
            _ = item ?? throw new NotFoundException($"Payout {request.Id} Not Found.");
            item = _mapper.Map(request, item);
            await _context.SaveChangesAsync(cancellationToken);
            return Result<int>.Success(item.Id);
        }
            else
            {
                var item = _mapper.Map<WalletPayout>(request);
                _context.WalletPayouts.Add(item);
                await _context.SaveChangesAsync(cancellationToken);
                return Result<int>.Success(item.Id);
            }
           
        }
    }

