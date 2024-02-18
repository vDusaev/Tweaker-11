namespace Tweaker11.Views;

public partial class ApplicationsPage : ContentView
{
	public ApplicationsPage()
	{
		InitializeComponent();
    }

    private async void RestoreTapped(object sender, EventArgs e)
    {
        await ((ApplicationsViewModel)BindingContext).RestoreTapped(sender, e);
    }

    private async void RemoveTapped(object sender, EventArgs e)
    {
        await ((ApplicationsViewModel)BindingContext).RemoveTapped(sender, e);
    }

    private async void DeleteTapped(object sender, EventArgs e)
    {
        await ((ApplicationsViewModel)BindingContext).DeleteTapped(sender, e);
    }
}