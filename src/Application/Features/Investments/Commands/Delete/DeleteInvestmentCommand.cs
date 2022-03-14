// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Investments.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Investments.Commands.Delete;

    public class DeleteInvestmentCommand: IRequest<Result>
    {
      public int Id {  get; set; }
    }
    public class DeleteCheckedInvestmentsCommand : IRequest<Result>
    {
      public int[] Id {  get; set; }
    }

    public class DeleteInvestmentCommandHandler : 
                 IRequestHandler<DeleteInvestmentCommand, Result>,
                 IRequestHandler<DeleteCheckedInvestmentsCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<DeleteInvestmentCommandHandler> _localizer;
        public DeleteInvestmentCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<DeleteInvestmentCommandHandler> localizer,
             IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result> Handle(DeleteInvestmentCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing DeleteInvestmentCommandHandler method 
           var item = await _context.Investments.FindAsync(new object[] { request.Id }, cancellationToken);
            _context.Investments.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        public async Task<Result> Handle(DeleteCheckedInvestmentsCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing DeleteCheckedInvestmentsCommandHandler method 
           var items = await _context.Investments.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken);
            foreach (var item in items)
            {
                _context.Investments.Remove(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }

