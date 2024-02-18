namespace Tweaker11.Services;

public static class ProcessService
{
    public static async Task<string> Command(string fileName, string script)
    {
        string result = string.Empty;

        using (Process process = new Process())
        {
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = script;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            using (var stream = process.StandardOutput)
            {
                result = await stream.ReadToEndAsync();
            }
        }

        return result;
    }
}
