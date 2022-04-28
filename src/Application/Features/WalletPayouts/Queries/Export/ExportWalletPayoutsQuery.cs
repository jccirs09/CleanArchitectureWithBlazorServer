// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using CleanArchitecture.Blazor.Application.Features.WalletPayouts.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletPayouts.Queries.Export;

public class ExportWalletPayoutsQuery : IRequest<byte[]>
{
    public string FilterRules { get; set; }
    public string Sort { get; set; } = "Id";
    public string Order { get; set; } = "desc";
}

public class ExportWalletPayoutsQueryHandler :
     IRequestHandler<ExportWalletPayoutsQuery, byte[]>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IExcelService _excelService;
    private readonly IStringLocalizer<ExportWalletPayoutsQueryHandler> _localizer;

    public ExportWalletPayoutsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        IExcelService excelService,
        IStringLocalizer<ExportWalletPayoutsQueryHandler> localizer
        )
    {
        _context = context;
        _mapper = mapper;
        _excelService = excelService;
        _localizer = localizer;
    }

    public async Task<byte[]> Handle(ExportWalletPayoutsQuery request, CancellationToken cancellationToken)
    {
        //TODO:Implementing ExportWalletPayoutsQueryHandler method 
        var filters = PredicateBuilder.FromFilter<WalletPayout>(request.FilterRules);
        var data = await _context.WalletPayouts.Where(filters)
                   .OrderBy("{request.Sort} {request.Order}")
                   .ProjectTo<WalletPayoutDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);
        var result = await _excelService.ExportAsync(data,
            new Dictionary<string, Func<WalletPayoutDto, object>>()
            {
                //{ _localizer["Id"], item => item.Id },
            }
            , _localizer["WalletPayouts"]);
        return result;
    }
}