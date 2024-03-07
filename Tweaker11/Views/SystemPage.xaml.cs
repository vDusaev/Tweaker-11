namespace Tweaker11.Views;

public partial class SystemPage : ContentView
{
	public SystemPage()
	{
		InitializeComponent();
	}

    private async void RestoreTapped(object sender, EventArgs e)
    {
        await ((SystemViewModel)BindingContext).RestoreTapped(sender, e);
    }

    private async void ActivateTapped(object sender, EventArgs e)
    {
        await ((SystemViewModel)BindingContext).ActivateTapped(sender, e);
    }
}