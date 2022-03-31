// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.WalletPayouts.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletPayouts.Commands.Delete;

    public class DeleteWalletPayoutCommand: IRequest<Result>
    {
      public int Id {  get; set; }
    }
    public class DeleteCheckedWalletPayoutsCommand : IRequest<Result>
    {
      public int[] Id {  get; set; }
    }

    public class DeleteWalletPayoutCommandHandler : 
                 IRequestHandler<DeleteWalletPayoutCommand, Result>,
                 IRequestHandler<DeleteCheckedWalletPayoutsCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<DeleteWalletPayoutCommandHandler> _localizer;
        public DeleteWalletPayoutCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<DeleteWalletPayoutCommandHandler> localizer,
             IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result> Handle(DeleteWalletPayoutCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing DeleteWalletPayoutCommandHandler method 
           var item = await _context.WalletPayouts.FindAsync(new object[] { request.Id }, cancellationToken);
            _context.WalletPayouts.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        public async Task<Result> Handle(DeleteCheckedWalletPayoutsCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing DeleteCheckedWalletPayoutsCommandHandler method 
           var items = await _context.WalletPayouts.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken);
            foreach (var item in items)
            {
                _context.WalletPayouts.Remove(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }

