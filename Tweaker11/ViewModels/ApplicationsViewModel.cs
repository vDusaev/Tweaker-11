namespace Tweaker11.ViewModels;

public partial class ApplicationsViewModel : BaseViewModel
{
    private ApplicationsService _applicationsService;

    public ObservableCollection<ApplicationItem> Applications { get; set; } = new();

    public ApplicationsViewModel()
    {
        _applicationsService = new ApplicationsService();

        Initialize();
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

    public async Task ChangeLanguage()
    {
        foreach (var application in Applications)
        {
            application.Text = Translator.Instance[application.Name];
        }
    }

    private async Task Initialize()
    {
        Applications = new()
        {
            new ApplicationItem()
            {
                Name = "Paint",
                Image = "paint.png",
                AppxName = "Microsoft.Paint"
            },
            new ApplicationItem()
            {
                Name = "Solitaire",
                Image = "solitaire.png",
                AppxName = "Microsoft.MicrosoftSolitaireCollection"
            },
            new ApplicationItem()
            {
                Name = "StickyNotes",
                Image = "sticky_notes.png",
                AppxName = "Microsoft.MicrosoftStickyNotes"
            },
            new ApplicationItem()
            {
                Name = "Alarms",
                Image = "alarms.png",
                AppxName = "Microsoft.WindowsAlarms"
            },
            new ApplicationItem()
            {
                Name = "YourPhone",
                Image = "your_phone.png",
                AppxName = "Microsoft.YourPhone"
            },
            new ApplicationItem()
            {
                Name = "BingWeather",
                Image = "weather.png",
                AppxName = "Microsoft.BingWeather"
            },
            new ApplicationItem()
            {
                Name = "SoundRecorder",
                Image = "sound_recorder.png",
                AppxName = "Microsoft.WindowsSoundRecorder"
            },
            new ApplicationItem()
            {
                Name = "Outlook",
                Image = "outlook.png",
                AppxName = "Microsoft.OutlookForWindows"
            }
        };

        await UpdateApplications();
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
}
