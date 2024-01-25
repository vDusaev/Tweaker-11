using System.Reflection;

namespace Tweaker11.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _homePageVisible;
    [ObservableProperty]
    private bool _applicationsPageVisible;

    [ObservableProperty]
    private HomeViewModel _homeViewModel;
    [ObservableProperty]
    private ApplicationsViewModel _applicationsViewModel;

    public MainPageViewModel(HomeViewModel homeViewModel, ApplicationsViewModel applicationsViewModel)
    {
        _homeViewModel = homeViewModel;
        _applicationsViewModel = applicationsViewModel;

        _homeViewModel.IsVisible = true;
    }

    [RelayCommand]
    private async Task NavigationClick(string page)
    {
        await ChangePage(page);
    }

    private async Task ChangePage(string currentPage)
    {
        HomePageVisible = currentPage == "HomePage";
        ApplicationsPageVisible = currentPage == "ApplicationsPage";

        HomeViewModel.IsVisible = HomePageVisible;
        ApplicationsViewModel.IsVisible = ApplicationsPageVisible;
    }
}
