// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.WalletPayouts.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.WalletPayouts.Commands.Import;

public class ImportWalletPayoutsCommand : IRequest<Result>
{
    public string FileName { get; set; }
    public byte[] Data { get; set; }
}
public class CreateWalletPayoutsTemplateCommand : IRequest<byte[]>
{
    public IEnumerable<string> Fields { get; set; }
    public string SheetName { get; set; }
}

public class ImportWalletPayoutsCommandHandler :
             IRequestHandler<CreateWalletPayoutsTemplateCommand, byte[]>,
             IRequestHandler<ImportWalletPayoutsCommand, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<ImportWalletPayoutsCommandHandler> _localizer;
    private readonly IExcelService _excelService;

    public ImportWalletPayoutsCommandHandler(
        IApplicationDbContext context,
        IExcelService excelService,
        IStringLocalizer<ImportWalletPayoutsCommandHandler> localizer,
        IMapper mapper
        )
    {
        _context = context;
        _localizer = localizer;
        _excelService = excelService;
        _mapper = mapper;
    }
    public async Task<Result> Handle(ImportWalletPayoutsCommand request, CancellationToken cancellationToken)
    {
        //TODO:Implementing ImportWalletPayoutsCommandHandler method
        var result = await _excelService.ImportAsync(request.Data, mappers: new Dictionary<string, Func<DataRow, WalletPayoutDto, object>>
        {
            //ex. { _localizer["Name"], (row,item) => item.Name = row[_localizer["Name"]]?.ToString() },

        }, _localizer["WalletPayouts"]);
        throw new System.NotImplementedException();
    }
    public async Task<byte[]> Handle(CreateWalletPayoutsTemplateCommand request, CancellationToken cancellationToken)
    {
        //TODO:Implementing ImportWalletPayoutsCommandHandler method 
        var fields = new string[] {
                   //TODO:Defines the title and order of the fields to be imported's template
                   //_localizer["Name"],
                };
        var result = await _excelService.CreateTemplateAsync(fields, _localizer["WalletPayouts"]);
        return result;
    }
}

