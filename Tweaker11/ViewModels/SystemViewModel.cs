namespace Tweaker11.ViewModels;

public partial class SystemViewModel : BaseViewModel
{
    [ObservableProperty]
    private bool _disableSecurityNotificationsActivate;
    [ObservableProperty]
    private bool _disableSecurityNotificationsRestore;

    public SystemViewModel()
    {
        Initialize();
    }

    public async Task ActivateTapped(object sender, EventArgs e)
    {
        var elementControl = sender as ElementControl;
        if (elementControl is null)
        {
            return;
        }

        switch (elementControl.Name)
        {
            case "DisableSecurityNotifications":
                await DisableSecurityNotifications();
                break;
        }
    }

    public async Task RestoreTapped(object sender, EventArgs e)
    {
        var elementControl = sender as ElementControl;
        if (elementControl is null)
        {
            return;
        }

        switch (elementControl.Name)
        {
            case "DisableSecurityNotifications":
                await DisableSecurityNotifications(1);
                break;
        }
    }

    private async Task Initialize()
    {
        await DisableSecurityNotifications(2);
    }

    private async Task DisableSecurityNotifications(byte operation = 0)
    {
        if (operation == 0)
        {
            await RegistryService.SetValue(@"SOFTWARE\Microsoft\Windows Defender Security Center\Notifications", "DisableNotifications", 1);
            await RegistryService.SetValue(@"SOFTWARE\Policies\Microsoft\Windows Defender Security Center\Notifications", "DisableNotifications", 1);

            await DisableSecurityNotifications(2);
        }
        else if (operation == 1)
        {
            await RegistryService.SetValue(@"SOFTWARE\Microsoft\Windows Defender Security Center\Notifications", "DisableNotifications", 0);
            await RegistryService.SetValue(@"SOFTWARE\Policies\Microsoft\Windows Defender Security Center\Notifications", "DisableNotifications", 0);

            await DisableSecurityNotifications(2);
        }
        else
        {
            DisableSecurityNotificationsActivate = false;
            DisableSecurityNotificationsRestore = false;

            var DisableNotifications = await RegistryService.GetValue(@"SOFTWARE\Microsoft\Windows Defender Security Center\Notifications", "DisableNotifications");
            if (DisableNotifications is null || (int)DisableNotifications == 0)
            {
                DisableSecurityNotificationsActivate = true;
                return;
            }

            DisableNotifications = await RegistryService.GetValue(@"SOFTWARE\Policies\Microsoft\Windows Defender Security Center\Notifications", "DisableNotifications");
            if (DisableNotifications is null || (int)DisableNotifications == 0)
            {
                DisableSecurityNotificationsActivate = true;
                return;
            }

            DisableSecurityNotificationsRestore = true;
        }
    }
}
