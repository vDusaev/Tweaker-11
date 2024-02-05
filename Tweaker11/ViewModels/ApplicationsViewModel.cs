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
}
