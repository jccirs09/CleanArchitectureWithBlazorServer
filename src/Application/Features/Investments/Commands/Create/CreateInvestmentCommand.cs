// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Investments.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Investments.Commands.Create;

public class CreateInvestmentCommand : InvestmentDto, IRequest<Result<int>>, IMapFrom<Investment>
{

}

public class CreateInvestmentCommandHandler : IRequestHandler<CreateInvestmentCommand, Result<int>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<CreateInvestmentCommand> _localizer;
    public CreateInvestmentCommandHandler(
        IApplicationDbContext context,
        IStringLocalizer<CreateInvestmentCommand> localizer,
        IMapper mapper
        )
    {
        _context = context;
        _localizer = localizer;
        _mapper = mapper;
    }
    public async Task<Result<int>> Handle(CreateInvestmentCommand request, CancellationToken cancellationToken)
    {
        //TODO:Implementing CreateInvestmentCommandHandler method 
        var item = _mapper.Map<Investment>(request);
        _context.Investments.Add(item);
        await _context.SaveChangesAsync(cancellationToken);
        return Result<int>.Success(item.Id);
    }
}

