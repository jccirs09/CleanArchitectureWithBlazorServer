// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using CleanArchitecture.Blazor.Application.Features.Wallets.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Wallets.Queries.Export;

public class ExportWalletsQuery : IRequest<byte[]>
{
    public string FilterRules { get; set; }
    public string Sort { get; set; } = "Id";
    public string Order { get; set; } = "desc";
}

public class ExportWalletsQueryHandler :
     IRequestHandler<ExportWalletsQuery, byte[]>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IExcelService _excelService;
    private readonly IStringLocalizer<ExportWalletsQueryHandler> _localizer;

    public ExportWalletsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        IExcelService excelService,
        IStringLocalizer<ExportWalletsQueryHandler> localizer
        )
    {
        _context = context;
        _mapper = mapper;
        _excelService = excelService;
        _localizer = localizer;
    }

    public async Task<byte[]> Handle(ExportWalletsQuery request, CancellationToken cancellationToken)
    {
        //TODO:Implementing ExportWalletsQueryHandler method 
        var filters = PredicateBuilder.FromFilter<Wallet>(request.FilterRules);
        var data = await _context.Wallets.Where(filters)
                   .OrderBy("{request.Sort} {request.Order}")
                   .ProjectTo<WalletDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);
        var result = await _excelService.ExportAsync(data,
            new Dictionary<string, Func<WalletDto, object>>()
            {
                //{ _localizer["Id"], item => item.Id },
            }
            , _localizer["Wallets"]);
        return result;
    }
}