namespace Tweaker11;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = base.CreateWindow(activationState);

        window.MinimumWidth = 1000;
        window.MinimumHeight = 520;

        return window;
    }
}
