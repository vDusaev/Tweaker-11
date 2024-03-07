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

    #region Button 1
    // Text.
    //
    public static readonly BindableProperty Button1TextProperty = BindableProperty.Create(
        "Button1Text",
        typeof(string),
        typeof(ElementControl),
        "",
        BindingMode.OneWay,
        null,
        null);

    public string Button1Text
    {
        get => (string)this.GetValue(Button1TextProperty);
        set => this.SetValue(Button1TextProperty, value);
    }

    // Visible.
    //
    public static readonly BindableProperty Button1VisibleProperty = BindableProperty.Create(
        "Button1Visible",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool Button1Visible
    {
        get => (bool)this.GetValue(Button1VisibleProperty);
        set => this.SetValue(Button1VisibleProperty, value);
    }

    // Active.
    //
    public static readonly BindableProperty Button1ActiveProperty = BindableProperty.Create(
        "Button1Active",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool Button1Active
    {
        get => (bool)this.GetValue(Button1ActiveProperty);
        set => this.SetValue(Button1ActiveProperty, value);
    }

    // Event.
    //
    public event EventHandler<EventArgs> EventButton1;

    private void Button1Tapped(object sender, EventArgs e)
    {
        EventButton1?.Invoke(this, e);
    }
    #endregion

    #region Button 2
    // Text.
    //
    public static readonly BindableProperty Button2TextProperty = BindableProperty.Create(
        "Button2Text",
        typeof(string),
        typeof(ElementControl),
        "",
        BindingMode.OneWay,
        null,
        null);

    public string Button2Text
    {
        get => (string)this.GetValue(Button2TextProperty);
        set => this.SetValue(Button2TextProperty, value);
    }

    // Visible.
    //
    public static readonly BindableProperty Button2VisibleProperty = BindableProperty.Create(
        "Button2Visible",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool Button2Visible
    {
        get => (bool)this.GetValue(Button2VisibleProperty);
        set => this.SetValue(Button2VisibleProperty, value);
    }

    // Active.
    //
    public static readonly BindableProperty Button2ActiveProperty = BindableProperty.Create(
        "Button2Active",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool Button2Active
    {
        get => (bool)this.GetValue(Button2ActiveProperty);
        set => this.SetValue(Button2ActiveProperty, value);
    }

    // Event.
    //
    public event EventHandler<EventArgs> EventButton2;

    private void Button2Tapped(object sender, EventArgs e)
    {
        EventButton2?.Invoke(this, e);
    }
    #endregion

    #region Button 3
    // Text.
    //
    public static readonly BindableProperty Button3TextProperty = BindableProperty.Create(
        "Button3Text",
        typeof(string),
        typeof(ElementControl),
        "",
        BindingMode.OneWay,
        null,
        null);

    public string Button3Text
    {
        get => (string)this.GetValue(Button3TextProperty);
        set => this.SetValue(Button3TextProperty, value);
    }

    // Visible.
    //
    public static readonly BindableProperty Button3VisibleProperty = BindableProperty.Create(
        "Button3Visible",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool Button3Visible
    {
        get => (bool)this.GetValue(Button3VisibleProperty);
        set => this.SetValue(Button3VisibleProperty, value);
    }

    // Active.
    //
    public static readonly BindableProperty Button3ActiveProperty = BindableProperty.Create(
        "Button3Active",
        typeof(bool),
        typeof(ElementControl),
        false,
        BindingMode.OneWay,
        null,
        null);

    public bool Button3Active
    {
        get => (bool)this.GetValue(Button3ActiveProperty);
        set => this.SetValue(Button3ActiveProperty, value);
    }

    // Event.
    //
    public event EventHandler<EventArgs> EventButton3;

    private void Button3Tapped(object sender, EventArgs e)
    {
        EventButton3?.Invoke(this, e);
    }
    #endregion

    public ElementControl()
	{
		InitializeComponent();
	}
}