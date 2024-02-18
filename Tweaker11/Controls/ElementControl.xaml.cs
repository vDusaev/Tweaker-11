namespace Tweaker11.Controls;

public partial class ElementControl : ContentView
{
    // Name.
    //
    public static readonly BindableProperty NameProperty = BindableProperty.Create(
        "Name",
        typeof(string),
        typeof(ElementControl),
        "",
        BindingMode.OneWay,
        null,
        null);

    public string Name
    {
        get => (string)this.GetValue(NameProperty);
        set => this.SetValue(NameProperty, value);
    }

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

    // Restore visible.
    //
    public static readonly BindableProperty RestoreVisibleProperty = BindableProperty.Create(
        "RestoreVisible",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool RestoreVisible
    {
        get => (bool)this.GetValue(RestoreVisibleProperty);
        set => this.SetValue(RestoreVisibleProperty, value);
    }

    // Restore active.
    //
    public static readonly BindableProperty RestoreActiveProperty = BindableProperty.Create(
        "RestoreActive",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool RestoreActive
    {
        get => (bool)this.GetValue(RestoreActiveProperty);
        set => this.SetValue(RestoreActiveProperty, value);
    }

    // Remove visible.
    //
    public static readonly BindableProperty RemoveVisibleProperty = BindableProperty.Create(
        "RemoveVisible",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool RemoveVisible
    {
        get => (bool)this.GetValue(RemoveVisibleProperty);
        set => this.SetValue(RemoveVisibleProperty, value);
    }

    // Remove active.
    //
    public static readonly BindableProperty RemoveActiveProperty = BindableProperty.Create(
        "RemoveActive",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool RemoveActive
    {
        get => (bool)this.GetValue(RemoveActiveProperty);
        set => this.SetValue(RemoveActiveProperty, value);
    }

    // Delete visible.
    //
    public static readonly BindableProperty DeleteVisibleProperty = BindableProperty.Create(
        "DeleteVisible",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool DeleteVisible
    {
        get => (bool)this.GetValue(DeleteVisibleProperty);
        set => this.SetValue(DeleteVisibleProperty, value);
    }

    // Delete active.
    //
    public static readonly BindableProperty DeleteActiveProperty = BindableProperty.Create(
        "DeleteActive",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool DeleteActive
    {
        get => (bool)this.GetValue(DeleteActiveProperty);
        set => this.SetValue(DeleteActiveProperty, value);
    }

    public event EventHandler<EventArgs> EventRestore;
    public event EventHandler<EventArgs> EventRemove;
    public event EventHandler<EventArgs> EventDelete;

    public ElementControl()
	{
		InitializeComponent();
	}

    private void RestoreTapped(object sender, EventArgs e)
    {
        EventRestore?.Invoke(this, e);
    }

    private void RemoveTapped(object sender, EventArgs e)
    {
        EventRemove?.Invoke(this, e);
    }

    private void DeleteTapped(object sender, EventArgs e)
    {
        EventDelete?.Invoke(this, e);
    }
}