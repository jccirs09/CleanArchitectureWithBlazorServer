// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Wallets.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Wallets.Commands.Import;

public class ImportWalletsCommand : IRequest<Result>
{
    public string FileName { get; set; }
    public byte[] Data { get; set; }
}
public class CreateWalletsTemplateCommand : IRequest<byte[]>
{
    public IEnumerable<string> Fields { get; set; }
    public string SheetName { get; set; }
}

public class ImportWalletsCommandHandler :
             IRequestHandler<CreateWalletsTemplateCommand, byte[]>,
             IRequestHandler<ImportWalletsCommand, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<ImportWalletsCommandHandler> _localizer;
    private readonly IExcelService _excelService;

    public ImportWalletsCommandHandler(
        IApplicationDbContext context,
        IExcelService excelService,
        IStringLocalizer<ImportWalletsCommandHandler> localizer,
        IMapper mapper
        )
    {
        _context = context;
        _localizer = localizer;
        _excelService = excelService;
        _mapper = mapper;
    }
    public async Task<Result> Handle(ImportWalletsCommand request, CancellationToken cancellationToken)
    {
        //TODO:Implementing ImportWalletsCommandHandler method
        var result = await _excelService.ImportAsync(request.Data, mappers: new Dictionary<string, Func<DataRow, WalletDto, object>>
        {
            //ex. { _localizer["Name"], (row,item) => item.Name = row[_localizer["Name"]]?.ToString() },

        }, _localizer["Wallets"]);
        throw new System.NotImplementedException();
    }
    public async Task<byte[]> Handle(CreateWalletsTemplateCommand request, CancellationToken cancellationToken)
    {
        //TODO:Implementing ImportWalletsCommandHandler method 
        var fields = new string[] {
                   //TODO:Defines the title and order of the fields to be imported's template
                   //_localizer["Name"],
                };
        var result = await _excelService.CreateTemplateAsync(fields, _localizer["Wallets"]);
        return result;
    }
}

