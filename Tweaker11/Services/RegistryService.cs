namespace Tweaker11.Services;

public static class RegistryService
{
    public static async Task SetValue(string subkey, string parameter, object value)
    {
        using (RegistryKey key = Registry.LocalMachine.CreateSubKey(subkey, true))
            key.SetValue(parameter, value);
    }

    public static async Task<object?> GetValue(string subkey, string parameter)
    {
        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(subkey, true))
        {
            if (key is not null)
                return key.GetValue(parameter, null);
        }

        return null;
    }
}
