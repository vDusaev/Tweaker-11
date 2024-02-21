namespace Tweaker11.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
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
    private bool _isOpenedLanguages;

    public ObservableCollection<LanguageItem> Languages { get; set; } = new();

    public MainPageViewModel(HomeViewModel homeViewModel, ApplicationsViewModel applicationsViewModel,
        SettingsService settingsService)
    {
        _settingsService = settingsService;
        
        // Initialize languages.
        InitializeLanguages();

        // Home page.
        _homeViewModel = homeViewModel;
        _homeViewModel.IsVisible = true;
        
        HomePageVisible = true;
        
        // Applications page.
        _applicationsViewModel = applicationsViewModel;
        _applicationsViewModel.SetApplicationsService(new ApplicationsService());
        _applicationsViewModel.Initialize();
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
    }
}
