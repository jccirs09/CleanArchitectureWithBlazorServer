// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using CleanArchitecture.Blazor.Application.Features.WalletTransactions.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.Queries.Export;

    public class ExportWalletTransactionsQuery : IRequest<byte[]>
    {
        public string FilterRules { get; set; }
        public string Sort { get; set; } = "Id";
        public string Order { get; set; } = "desc";
    }
    
    public class ExportWalletTransactionsQueryHandler :
         IRequestHandler<ExportWalletTransactionsQuery, byte[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;
        private readonly IStringLocalizer<ExportWalletTransactionsQueryHandler> _localizer;

        public ExportWalletTransactionsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IExcelService excelService,
            IStringLocalizer<ExportWalletTransactionsQueryHandler> localizer
            )
        {
            _context = context;
            _mapper = mapper;
            _excelService = excelService;
            _localizer = localizer;
        }

        public async Task<byte[]> Handle(ExportWalletTransactionsQuery request, CancellationToken cancellationToken)
        {
            //TODO:Implementing ExportWalletTransactionsQueryHandler method 
            var filters = PredicateBuilder.FromFilter<WalletTransaction>(request.FilterRules);
            var data = await _context.WalletTransactions.Where(filters)
                       .OrderBy("{request.Sort} {request.Order}")
                       .ProjectTo<WalletTransactionDto>(_mapper.ConfigurationProvider)
                       .ToListAsync(cancellationToken);
            var result = await _excelService.ExportAsync(data,
                new Dictionary<string, Func<WalletTransactionDto, object>>()
                {
                    //{ _localizer["Id"], item => item.Id },
                }
                , _localizer["WalletTransactions"]);
            return result;
        }
    }