namespace Tweaker11.Services;

public class ApplicationsService
{
    private string _pathProgramFiles;
    private string _pathWindowsApps;
    private bool _existsWindowsApps;

    public ApplicationsService()
    {
        _pathProgramFiles = GetPathProgramFiles();
        _pathWindowsApps = _pathProgramFiles + "\\WindowsApps";
        _existsWindowsApps = Directory.Exists(_pathWindowsApps);
    }

    public async Task<string> GetInstallAppxPackage()
    {
        return await ProcessService.Command("powershell.exe", 
            "Get-AppxPackage | Select PackageFullName");
    }

    public async Task<string> GetInstallAppxPackage(string appxName)
    {
        return await ProcessService.Command("powershell.exe", 
                $"Get-AppxPackage | Select PackageFullName | Where-Object {{$_.PackageFullName -Like “*{ appxName }*”}}");
    }

    public async Task<string> GetFileAppxPackage()
    {
        if (!_existsWindowsApps)
        {
            return string.Empty;
        }

        return await ProcessService.Command("powershell.exe", 
            $"Get-ChildItem '{ _pathWindowsApps }' | Select Name");
    }

    public async Task<string> GetFileAppxPackage(string appxName)
    {
        if (!_existsWindowsApps)
        {
            return string.Empty;
        }

        return await ProcessService.Command("powershell.exe",
            $"Get-ChildItem '{ _pathWindowsApps }' | Select Name | Where-Object {{$_.Name -Like “*{ appxName }*”}}");
    }

    public async Task RemoveAppx(string packageFullName)
    {
        await ProcessService.Command("powershell.exe",
            $"Remove-AppxPackage { packageFullName }");
    }

    public async Task RestoreAppx(string appxName)
    {
        await ProcessService.Command("powershell.exe",
           $"Get-AppXPackage *{ appxName }* -AllUsers | Foreach {{Add-AppxPackage -DisableDevelopmentMode -Register “$($_.InstallLocation)\\AppXManifest.xml”}}");
    }

    public async Task DeleteAppx(string appxName, string packageFullName)
    {
        await ProcessService.Command("powershell.exe",
           $"Get-AppxProvisionedPackage -Online | Where-Object {{$_.PackageName -Like “*{appxName}*”}} | Remove-AppxProvisionedPackage -Online -Verbose");
        await ProcessService.Command("powershell.exe",
           $"Remove-AppxPackage {packageFullName}");
    }

    public async Task<string> FindAppxPackage(string stringPowerShell, string appxName)
    {
        string pattern = $@"{ appxName }_\S*";

        foreach (Match match in Regex.Matches(stringPowerShell, pattern, RegexOptions.IgnoreCase))
        {
            return match.Value;
        }

        return string.Empty;
    }

    private string GetPathProgramFiles()
    {
        string folderProgramFiles = string.Empty;

        if (Environment.Is64BitOperatingSystem)
        {
            folderProgramFiles = Environment.Is64BitProcess
                ? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                : Environment.GetEnvironmentVariable("ProgramW6432");
        }
        else
        {
            folderProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        }

        return folderProgramFiles;
    }
}
