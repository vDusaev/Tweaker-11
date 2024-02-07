namespace Tweaker11.ViewModels;

public partial class ApplicationsViewModel : BaseViewModel
{
    private ApplicationsService _applicationsService;

    public void SetApplicationsService(ApplicationsService applicationsService)
    { 
        _applicationsService = applicationsService;
    }

    public async void Initialize()
    {
        
    }

    public void RefreshTapped(object sender, EventArgs e)
    {
        
    }

    public void TrashTapped(object sender, EventArgs e)
    {

    }
}
