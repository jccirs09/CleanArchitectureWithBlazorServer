// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.WalletTransactions.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.Commands.Import;

    public class ImportWalletTransactionsCommand: IRequest<Result>
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
    public class CreateWalletTransactionsTemplateCommand : IRequest<byte[]>
    {
        public IEnumerable<string> Fields { get; set; }
        public string SheetName { get; set; }
    }

    public class ImportWalletTransactionsCommandHandler : 
                 IRequestHandler<CreateWalletTransactionsTemplateCommand, byte[]>,
                 IRequestHandler<ImportWalletTransactionsCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<ImportWalletTransactionsCommandHandler> _localizer;
        private readonly IExcelService _excelService;

        public ImportWalletTransactionsCommandHandler(
            IApplicationDbContext context,
            IExcelService excelService,
            IStringLocalizer<ImportWalletTransactionsCommandHandler> localizer,
            IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _excelService = excelService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(ImportWalletTransactionsCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing ImportWalletTransactionsCommandHandler method
           var result = await _excelService.ImportAsync(request.Data, mappers: new Dictionary<string, Func<DataRow, WalletTransactionDto, object>>
            {
                //ex. { _localizer["Name"], (row,item) => item.Name = row[_localizer["Name"]]?.ToString() },

            }, _localizer["WalletTransactions"]);
           throw new System.NotImplementedException();
        }
        public async Task<byte[]> Handle(CreateWalletTransactionsTemplateCommand request, CancellationToken cancellationToken)
        {
            //TODO:Implementing ImportWalletTransactionsCommandHandler method 
            var fields = new string[] {
                   //TODO:Defines the title and order of the fields to be imported's template
                   //_localizer["Name"],
                };
            var result = await _excelService.CreateTemplateAsync(fields, _localizer["WalletTransactions"]);
            return result;
        }
    }

