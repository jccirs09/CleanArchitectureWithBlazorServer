// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using CleanArchitecture.Blazor.Application.Features.Investments.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Investments.Queries.Export;

public class ExportInvestmentsQuery : IRequest<byte[]>
{
    public string FilterRules { get; set; }
    public string Sort { get; set; } = "Id";
    public string Order { get; set; } = "desc";
}

public class ExportInvestmentsQueryHandler :
     IRequestHandler<ExportInvestmentsQuery, byte[]>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IExcelService _excelService;
    private readonly IStringLocalizer<ExportInvestmentsQueryHandler> _localizer;

    public ExportInvestmentsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        IExcelService excelService,
        IStringLocalizer<ExportInvestmentsQueryHandler> localizer
        )
    {
        _context = context;
        _mapper = mapper;
        _excelService = excelService;
        _localizer = localizer;
    }

    public async Task<byte[]> Handle(ExportInvestmentsQuery request, CancellationToken cancellationToken)
    {
        //TODO:Implementing ExportInvestmentsQueryHandler method 
        var filters = PredicateBuilder.FromFilter<Investment>(request.FilterRules);
        var data = await _context.Investments.Where(filters)
                   .OrderBy("{request.Sort} {request.Order}")
                   .ProjectTo<InvestmentDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);
        var result = await _excelService.ExportAsync(data,
            new Dictionary<string, Func<InvestmentDto, object>>()
            {
                //{ _localizer["Id"], item => item.Id },
            }
            , _localizer["Investments"]);
        return result;
    }
}