using MudBlazor;
using MudBlazor.Utilities;

namespace Blazor.Server.UI.Pages.Investor;

public partial class InvestorWallet :  MudComponentBase
{
    private string Classname =>
        new CssBuilder()
            .AddClass(Class)
            .Build();
}
