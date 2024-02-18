namespace Tweaker11.ViewModels;

public partial class ApplicationsViewModel : BaseViewModel
{
    private ApplicationsService _applicationsService;

    public ObservableCollection<ApplicationItem> Applications { get; set; } = new();

    public void SetApplicationsService(ApplicationsService applicationsService)
    { 
        _applicationsService = applicationsService;
    }

    public async void Initialize()
    {
        await InitializeApplications();
        await UpdateApplications();
    }

    public async Task RestoreTapped(object sender, EventArgs e)
    {
        var elementControl = sender as ElementControl;
        if (elementControl is null)
        {
            return;
        }

        var application = Applications.FirstOrDefault(a => a.Name == elementControl.Name);
        if (application is null)
        {
            return;
        }

        await UpdateApplication(application);

        if (!application.RestoreActive)
        {
            return;
        }

        await _applicationsService.RestoreAppx(application.AppxName);

        await UpdateApplication(application);
    }

    public async Task RemoveTapped(object sender, EventArgs e)
    {
        var elementControl = sender as ElementControl;
        if (elementControl is null)
        {
            return;
        }

        var application = Applications.FirstOrDefault(a => a.Name == elementControl.Name);
        if (application is null)
        {
            return;
        }

        await UpdateApplication(application);

        if (!application.RemoveActive)
        {
            return;
        }

        await _applicationsService.RemoveAppx(application.AppxInstallPackage);

        await UpdateApplication(application);
    }

    public async Task DeleteTapped(object sender, EventArgs e)
    {
        var elementControl = sender as ElementControl;
        if (elementControl is null)
        {
            return;
        }

        var application = Applications.FirstOrDefault(a => a.Name == elementControl.Name);
        if (application is null)
        {
            return;
        }

        await UpdateApplication(application);

        if (!application.DeleteActive)
        {
            return;
        }

        await _applicationsService.DeleteAppx(application.AppxName, application.AppxInstallPackage);

        await UpdateApplication(application);
    }

    private async Task UpdateApplication(ApplicationItem application)
    {
        var installAppxPackage = await _applicationsService.GetInstallAppxPackage(application.AppxName);
        var fileAppxPackage = await _applicationsService.GetFileAppxPackage(application.AppxName);

        application.AppxInstallPackage = await _applicationsService.FindAppxPackage(installAppxPackage, application.AppxName);
        application.AppxFilePackage = await _applicationsService.FindAppxPackage(fileAppxPackage, application.AppxName);

        application.RestoreActive = false;
        application.RemoveActive = false;
        application.DeleteActive = false;

        if (!string.IsNullOrEmpty(application.AppxInstallPackage))
        {
            application.RemoveActive = true;
            application.DeleteActive = true;
        }
        else if (!string.IsNullOrEmpty(application.AppxFilePackage))
        {
            application.RestoreActive = true;
        }
    }

    private async Task UpdateApplications()
    {
        var installAppxPackage = await _applicationsService.GetInstallAppxPackage();
        var fileAppxPackage = await _applicationsService.GetFileAppxPackage();

        foreach (var application in Applications)
        {
            application.AppxInstallPackage = await _applicationsService.FindAppxPackage(installAppxPackage, application.AppxName);
            application.AppxFilePackage = await _applicationsService.FindAppxPackage(fileAppxPackage, application.AppxName);

            application.RestoreActive = false;
            application.RemoveActive = false;
            application.DeleteActive = false;

            if (!string.IsNullOrEmpty(application.AppxInstallPackage))
            {
                application.RemoveActive = true;
                application.DeleteActive = true;
            }
            else if (!string.IsNullOrEmpty(application.AppxFilePackage))
            {
                application.RestoreActive = true;
            }
        }
    }

    private async Task InitializeApplications()
    {
        Applications.Add(new ApplicationItem()
        {
            Name = "Paint",
            Image = "paint.png",
            Text = "Paint",
            AppxName = "Microsoft.Paint"
        });

        Applications.Add(new ApplicationItem()
        {
            Name = "Solitaire",
            Image = "solitaire.png",
            Text = "Solitaire & Casual Games",
            AppxName = "Microsoft.MicrosoftSolitaireCollection"
        });

        Applications.Add(new ApplicationItem()
        {
            Name = "StickyNotes",
            Image = "sticky_notes.png",
            Text = "Записки",
            AppxName = "Microsoft.MicrosoftStickyNotes"
        });

        Applications.Add(new ApplicationItem()
        {
            Name = "Alarms",
            Image = "alarms.png",
            Text = "Часы",
            AppxName = "Microsoft.WindowsAlarms"
        });
    }
}
