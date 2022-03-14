// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Investments.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Investments.Commands.Update;

    public class UpdateInvestmentCommand: InvestmentDto,IRequest<Result>, IMapFrom<Investment>
    {
        
    }

    public class UpdateInvestmentCommandHandler : IRequestHandler<UpdateInvestmentCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<UpdateInvestmentCommandHandler> _localizer;
        public UpdateInvestmentCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<UpdateInvestmentCommandHandler> localizer,
             IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result> Handle(UpdateInvestmentCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing UpdateInvestmentCommandHandler method 
           var item =await _context.Investments.FindAsync( new object[] { request.Id }, cancellationToken);
           if (item != null)
           {
                item = _mapper.Map(request, item);
                await _context.SaveChangesAsync(cancellationToken);
           }
           return Result.Success();
        }
    }

