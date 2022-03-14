// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Investments.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Investments.Commands.Import;

    public class ImportInvestmentsCommand: IRequest<Result>
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
    public class CreateInvestmentsTemplateCommand : IRequest<byte[]>
    {
        public IEnumerable<string> Fields { get; set; }
        public string SheetName { get; set; }
    }

    public class ImportInvestmentsCommandHandler : 
                 IRequestHandler<CreateInvestmentsTemplateCommand, byte[]>,
                 IRequestHandler<ImportInvestmentsCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<ImportInvestmentsCommandHandler> _localizer;
        private readonly IExcelService _excelService;

        public ImportInvestmentsCommandHandler(
            IApplicationDbContext context,
            IExcelService excelService,
            IStringLocalizer<ImportInvestmentsCommandHandler> localizer,
            IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _excelService = excelService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(ImportInvestmentsCommand request, CancellationToken cancellationToken)
        {
           //TODO:Implementing ImportInvestmentsCommandHandler method
           var result = await _excelService.ImportAsync(request.Data, mappers: new Dictionary<string, Func<DataRow, InvestmentDto, object>>
            {
                //ex. { _localizer["Name"], (row,item) => item.Name = row[_localizer["Name"]]?.ToString() },

            }, _localizer["Investments"]);
           throw new System.NotImplementedException();
        }
        public async Task<byte[]> Handle(CreateInvestmentsTemplateCommand request, CancellationToken cancellationToken)
        {
            //TODO:Implementing ImportInvestmentsCommandHandler method 
            var fields = new string[] {
                   //TODO:Defines the title and order of the fields to be imported's template
                   //_localizer["Name"],
                };
            var result = await _excelService.CreateTemplateAsync(fields, _localizer["Investments"]);
            return result;
        }
    }

