// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using CleanArchitecture.Blazor.Application.Features.Investments.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Investments.Commands.AddEdit;

public class AddEditInvestmentCommand : InvestmentDto, IRequest<Result<int>>, IMapFrom<Investment>
{

}

public class AddEditInvestmentCommandHandler : IRequestHandler<AddEditInvestmentCommand, Result<int>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<AddEditInvestmentCommandHandler> _localizer;
    public AddEditInvestmentCommandHandler(
        IApplicationDbContext context,
        IStringLocalizer<AddEditInvestmentCommandHandler> localizer,
        IMapper mapper
        )
    {
        _context = context;
        _localizer = localizer;
        _mapper = mapper;
    }
    public async Task<Result<int>> Handle(AddEditInvestmentCommand request, CancellationToken cancellationToken)
    {
        //TODO:Implementing AddEditInvestmentCommandHandler method 
        if (request.Id > 0)
        {
            var item = await _context.Investments.FindAsync(new object[] { request.Id }, cancellationToken);
            _ = item ?? throw new NotFoundException($"Investment {request.Id} Not Found.");
            item = _mapper.Map(request, item);
            await _context.SaveChangesAsync(cancellationToken);
            return Result<int>.Success(item.Id);
        }
        else
        {
            var item = _mapper.Map<Investment>(request);
            _context.Investments.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
            return Result<int>.Success(item.Id);
        }

    }
}

