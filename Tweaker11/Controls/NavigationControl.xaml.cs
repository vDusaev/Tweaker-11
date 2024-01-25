namespace Tweaker11.Controls;

public partial class NavigationControl : ContentView
{
    // Name page.
    //

    public static readonly BindableProperty NamePageProperty = BindableProperty.Create(
        "NamePage",
        typeof(string),
        typeof(NavigationControl),
        "",
        BindingMode.OneWay,
        null,
        null);

    public string NamePage
    {
        get => (string)this.GetValue(NamePageProperty);
        set => this.SetValue(NamePageProperty, value);
    }

    // Image name.
    //

    public static readonly BindableProperty ImageProperty = BindableProperty.Create(
        "Image",
        typeof(string),
        typeof(NavigationControl),
        "",
        BindingMode.OneWay,
        null,
        null);

    public string Image
    {
        get => (string)this.GetValue(ImageProperty);
        set => this.SetValue(ImageProperty, value);
    }

    // Text.
    //

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        "Text",
        typeof(string),
        typeof(NavigationControl),
        "",
        BindingMode.OneWay,
        null,
        null);

    public string Text
    {
        get => (string)this.GetValue(TextProperty);
        set => this.SetValue(TextProperty, value);
    }

    // Is visible.
    //

    public static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(
        "IsVisible",
        typeof(bool),
        typeof(NavigationControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool IsVisible
    {
        get => (bool)this.GetValue(IsVisibleProperty);
        set => this.SetValue(IsVisibleProperty, value);
    }

    public NavigationControl()
	{
		InitializeComponent();
	}
}