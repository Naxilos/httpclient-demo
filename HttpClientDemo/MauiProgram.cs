using Microsoft.Extensions.Logging;
using CommunityToolkit.Mvvm;
using HttpClientDemo.API;

namespace HttpClientDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton(typeof(MainPage));
		builder.Services.AddSingleton(typeof(MainPageViewModel));

		builder.Services.AddSingleton(typeof(DummyClient));

		return builder.Build();
	}
}

