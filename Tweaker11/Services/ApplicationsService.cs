namespace Tweaker11.Services;

public class ApplicationsService
{
    private PowerShellServices _powerShellServices;

    public ApplicationsService(PowerShellServices powerShellServices)
    {
        _powerShellServices = powerShellServices;
    }
}
