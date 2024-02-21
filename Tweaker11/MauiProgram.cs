using Microsoft.Extensions.Logging;

namespace Tweaker11
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SegoeUI.ttf", "SegoeUI");
                    fonts.AddFont("SegoeUIBold.ttf", "SegoeUIBold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // Register settings service.
            builder.Services.AddSingleton<SettingsService>();

            // Pages.
            builder.Services.AddSingleton<MainPage>();

            // View models.
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<ApplicationsViewModel>();

            return builder.Build();
        }
    }
}
