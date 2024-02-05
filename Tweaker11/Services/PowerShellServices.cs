using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Tweaker11.Services;

public class PowerShellServices
{
    private PowerShell _powerShell;

    public PowerShellServices()
    {
        var sessionState = InitialSessionState.CreateDefault();
        sessionState.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.Unrestricted;

        _powerShell = PowerShell.Create(sessionState);
    }

    public async Task<string> Command(string script)
    {
        _powerShell.AddScript(script);

        // Make sure return values are outputted to the stream captured by C#.
        _powerShell.AddCommand("Out-String");

        string errorMsg = string.Empty;

        PSDataCollection<PSObject> outputCollection = new();
        _powerShell.Streams.Error.DataAdded += (object sender, DataAddedEventArgs e) =>
        {
            errorMsg = ((PSDataCollection<ErrorRecord>)sender)[e.Index].ToString();
        };

        IAsyncResult result = _powerShell.BeginInvoke<PSObject, PSObject>(null, outputCollection);

        // Wait for powershell command/script to finish executing.
        _powerShell.EndInvoke(result);

        StringBuilder sb = new();
        foreach (var outputItem in outputCollection)
        {
            sb.AppendLine(outputItem.BaseObject.ToString());
        }

        // Clears the commands we added to the powershell runspace so it's empty the next time we use it.
        _powerShell.Commands.Clear();

        // If an error is encountered, return it.
        if (!string.IsNullOrEmpty(errorMsg))
        {
            throw new Exception(errorMsg);
        }

        return sb.ToString().Trim();
    }
}
