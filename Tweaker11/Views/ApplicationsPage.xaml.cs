namespace Tweaker11.Views;

public partial class ApplicationsPage : ContentView
{
	public ApplicationsPage()
	{
		InitializeComponent();
    }

    private void RefreshTapped(object sender, EventArgs e)
    {
        ((ApplicationsViewModel)BindingContext).RefreshTapped(sender, e);
    }

    private void TrashTapped(object sender, EventArgs e)
    {
        ((ApplicationsViewModel)BindingContext).TrashTapped(sender, e);
    }
}