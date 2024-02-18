namespace Tweaker11.Models;

public partial class ApplicationItem : ObservableObject
{
    public string Name { get; set; }
    public string? Image { get; set; }
    public string? Text { get; set; }
    public string? AppxName { get; set; }
    public string? AppxInstallPackage { get; set; }
    public string? AppxFilePackage { get; set; }
    [ObservableProperty]
    private bool _restoreActive;
    [ObservableProperty]
    private bool _RemoveActive;
    [ObservableProperty]
    private bool _deleteActive;
}
