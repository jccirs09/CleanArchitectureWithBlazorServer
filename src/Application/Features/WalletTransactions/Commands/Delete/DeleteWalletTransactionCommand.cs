// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.WalletTransactions.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.Commands.Delete;

    public class DeleteWalletTransactionCommand: IRequest<Result>
    {
      public int Id {  get; set; }
    }
    public class DeleteCheckedWalletTransactionsCommand : IRequest<Result>
    {
      public int[] Id {  get; set; }
    }

    public class DeleteWalletTransactionCommandHandler : 
                 IRequestHandler<DeleteWalletTransactionCommand, Result>,
                 IRequestHandler<DeleteCheckedWalletTransactionsCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<DeleteWalletTransactionCommandHandler> _localizer;
        public DeleteWalletTransactionCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<DeleteWalletTransactionCommandHandler> localizer,
             IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result> Handle(DeleteWalletTransactionCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing DeleteWalletTransactionCommandHandler method 
           var item = await _context.WalletTransactions.FindAsync(new object[] { request.Id }, cancellationToken);
            _context.WalletTransactions.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        public async Task<Result> Handle(DeleteCheckedWalletTransactionsCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing DeleteCheckedWalletTransactionsCommandHandler method 
           var items = await _context.WalletTransactions.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken);
            foreach (var item in items)
            {
                _context.WalletTransactions.Remove(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }

