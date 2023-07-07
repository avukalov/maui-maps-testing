using Camera.MAUI;
using CommunityToolkit.Maui;
using GoogleMaps.View;
using GoogleMaps.ViewModel;
using Microsoft.Extensions.Logging;
using GoogleMaps.Platforms;
using The49.Maui.BottomSheet;
using GoogleMaps.Control;

namespace GoogleMaps;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseMauiMaps()
			.UseMauiCameraView();

		builder
			.RegisterAppServices()
			.RegisterViewModels()
			.RegisterViews();

		builder
			.ConfigureMauiHandlers(handlers =>
			{
				#if ANDROID
					handlers.AddHandler<Microsoft.Maui.Controls.Maps.Map, CustomMapHandler>();
				#endif
				
			});

        builder
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		#if DEBUG
			builder.Logging.AddDebug();
		#endif

        return builder.Build();
	}

	public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
	{
		return builder;
	}

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MapViewModel>();
        builder.Services.AddSingleton<AboutViewModel>();

        return builder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MapPage>();
        builder.Services.AddSingleton<AboutPage>();

        return builder;
    }
}
