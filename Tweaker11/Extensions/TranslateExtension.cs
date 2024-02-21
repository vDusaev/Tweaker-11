namespace Tweaker11.Extensions;

[ContentProperty(nameof(Key))]
public class TranslateExtension : IMarkupExtension 
{
    public string Key { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return new Binding
        {
            Mode = BindingMode.OneWay,
            Path = $"[{Key}]",
            Source = Translator.Instance
        };
    }
}
