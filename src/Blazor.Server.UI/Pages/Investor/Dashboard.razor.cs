using MudBlazor;
using MudBlazor.Utilities;

namespace Blazor.Server.UI.Pages.Investor;

public partial class Dashboard : MudComponentBase
{
    private string Classname =>
        new CssBuilder()
            .AddClass(Class)
            .Build();
}
