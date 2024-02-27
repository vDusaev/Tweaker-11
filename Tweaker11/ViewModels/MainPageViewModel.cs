namespace Tweaker11.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private string _currentPage;

    private SettingsService _settingsService;

    [ObservableProperty]
    private bool _homePageVisible;
    [ObservableProperty]
    private bool _applicationsPageVisible;

    [ObservableProperty]
    private HomeViewModel _homeViewModel;
    [ObservableProperty]
    private ApplicationsViewModel _applicationsViewModel;

    [ObservableProperty]
    private string _title;
    [ObservableProperty]
    private bool _isOpenedLanguages;

    public ObservableCollection<LanguageItem> Languages { get; set; } = new();

    public MainPageViewModel(HomeViewModel homeViewModel, ApplicationsViewModel applicationsViewModel,
        SettingsService settingsService)
    {
        _currentPage = "HomePage";
        _settingsService = settingsService;
        
        // Home page.
        _homeViewModel = homeViewModel;
        
        // Applications page.
        _applicationsViewModel = applicationsViewModel;

        // Initialize languages.
        InitializeLanguages();

        // Start page.
        ChangePage(_currentPage);
    }

    [RelayCommand]
    private async Task NavigationClick(string page)
    {
        await ChangePage(page);
    }

    [RelayCommand]
    private async Task LanguageClick(string selectedLanguage)
    {
        await ChangeLanguage(selectedLanguage);
        await _settingsService.Save<string>("language", selectedLanguage);
    }

    private async Task InitializeLanguages()
    {
        Languages = new()
        {
            new LanguageItem() { Name = "en-US", DisplayName = "English" },
            new LanguageItem() { Name = "ru-RU", DisplayName = "Русский" },
        };

        var selectedLanguage = await _settingsService.Get<string>("language", "en-US");
        await ChangeLanguage(selectedLanguage);
    }

    private async Task ChangePage(string currentPage)
    {
        _currentPage = currentPage;

        Title = Translator.Instance[_currentPage];

        HomePageVisible = currentPage == "HomePage";
        ApplicationsPageVisible = currentPage == "ApplicationsPage";

        HomeViewModel.IsVisible = HomePageVisible;
        ApplicationsViewModel.IsVisible = ApplicationsPageVisible;
    }

    private async Task ChangeLanguage(string selectedLanguage)
    {
        IsOpenedLanguages = false;

        if (string.IsNullOrEmpty(selectedLanguage))
        {
            selectedLanguage = "en-US";
        }

        Translator.Instance.CultureInfo = new CultureInfo(selectedLanguage);
        Translator.Instance.OnPropertyChanged();

        Title = Translator.Instance[_currentPage];

        await ApplicationsViewModel.ChangeLanguage();
    }
}
