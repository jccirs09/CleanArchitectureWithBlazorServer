using MudBlazor;
using MudBlazor.Utilities;

namespace Blazor.Server.UI.Components.InvestorsDashboard;

public partial class InvestorsInvestmentCount : MudComponentBase
{
    private string Classname =>
        new CssBuilder()
            .AddClass(Class)
            .Build();
}