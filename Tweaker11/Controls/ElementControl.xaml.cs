namespace Tweaker11.Controls;

public partial class ElementControl : ContentView
{
    // Image.
    //
    public static readonly BindableProperty ImageProperty = BindableProperty.Create(
        "Image",
        typeof(string),
        typeof(ElementControl),
        "",
        BindingMode.OneWay,
        null,
        null);

    public string Image
    {
        get => (string)this.GetValue(ImageProperty);
        set => this.SetValue(ImageProperty, value);
    }

    // Image visible.
    //
    public bool ImageVisible
    {
        get => !string.IsNullOrWhiteSpace(Image);
    }

    // Text.
    //
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        "Text",
        typeof(string),
        typeof(ElementControl),
        "",
        BindingMode.OneWay,
        null,
        null);

    public string Text
    {
        get => (string)this.GetValue(TextProperty);
        set => this.SetValue(TextProperty, value);
    }

    // Trash visible.
    //
    public static readonly BindableProperty TrashVisibleProperty = BindableProperty.Create(
        "TrashVisible",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool TrashVisible
    {
        get => (bool)this.GetValue(TrashVisibleProperty);
        set => this.SetValue(TrashVisibleProperty, value);
    }

    // Refresh visible.
    //
    public static readonly BindableProperty RefreshVisibleProperty = BindableProperty.Create(
        "RefreshVisible",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool RefreshVisible
    {
        get => (bool)this.GetValue(RefreshVisibleProperty);
        set => this.SetValue(RefreshVisibleProperty, value);
    }

    public event EventHandler<EventArgs> EventRefresh;
    public event EventHandler<EventArgs> EventTrash;

    public ElementControl()
	{
		InitializeComponent();
	}

    private void RefreshTapped(object sender, EventArgs e)
    {
        EventRefresh?.Invoke(this, e);
    }

    private void TrashTapped(object sender, EventArgs e)
    {
        EventTrash?.Invoke(this, e);
    }
}