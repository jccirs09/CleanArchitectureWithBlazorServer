namespace Blazor.Server.UI.Models;

public class ThemeManagerModel
{
    public bool IsDarkMode { get; set; } = true;
    public string PrimaryColor { get; set; } = "#c7ab0e";
    public double BorderRadius { get; set; } = 4;
}