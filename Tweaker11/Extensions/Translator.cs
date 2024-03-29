﻿namespace Tweaker11.Extensions;

public class Translator : INotifyPropertyChanged
{
    public string this[string key]
    {
        get => AppResources.ResourceManager.GetString(key, CultureInfo);
    }
    public CultureInfo CultureInfo { get; set; }

    public static Translator Instance { get; } = new();

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
