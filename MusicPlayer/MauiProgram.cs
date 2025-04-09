using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MusicPlayer.Services;

namespace MusicPlayer
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.UseMauiCommunityToolkitMediaElement()
				.ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

			const string baseUrl = "http://192.168.3.11:5000";
			//const string baseUrl = "http://10.0.2.2:5000";
			builder.Services.AddSingleton<MusicApiService>(new MusicApiService(baseUrl));

			return builder.Build();
        }
    }
}
