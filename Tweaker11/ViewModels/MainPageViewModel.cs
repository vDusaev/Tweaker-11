﻿using System.Reflection;

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

    private PowerShellServices _powerShellServices;

    public MainPageViewModel(HomeViewModel homeViewModel, ApplicationsViewModel applicationsViewModel, 
        PowerShellServices powerShellServices)
    {
        _powerShellServices = powerShellServices;

        // Home page.
        _homeViewModel = homeViewModel;
        _homeViewModel.IsVisible = true;
        
        HomePageVisible = true;

        // Applications page.
        _applicationsViewModel = applicationsViewModel;
        _applicationsViewModel.SetApplicationsService(new ApplicationsService(_powerShellServices));
        _applicationsViewModel.Initialize();
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
