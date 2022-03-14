// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Wallets.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Wallets.Commands.Delete;

    public class DeleteWalletCommand: IRequest<Result>
    {
      public int Id {  get; set; }
    }
    public class DeleteCheckedWalletsCommand : IRequest<Result>
    {
      public int[] Id {  get; set; }
    }

    public class DeleteWalletCommandHandler : 
                 IRequestHandler<DeleteWalletCommand, Result>,
                 IRequestHandler<DeleteCheckedWalletsCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<DeleteWalletCommandHandler> _localizer;
        public DeleteWalletCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<DeleteWalletCommandHandler> localizer,
             IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing DeleteWalletCommandHandler method 
           var item = await _context.Wallets.FindAsync(new object[] { request.Id }, cancellationToken);
            _context.Wallets.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        public async Task<Result> Handle(DeleteCheckedWalletsCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing DeleteCheckedWalletsCommandHandler method 
           var items = await _context.Wallets.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken);
            foreach (var item in items)
            {
                _context.Wallets.Remove(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }

