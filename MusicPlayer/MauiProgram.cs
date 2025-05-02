using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MusicPlayer.Services;
using Plugin.Maui.Audio;
using MusicPlayer.ViewModels;
using MusicPlayer.Views;

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

			const string baseUrl = "http://192.168.1.8:5000";
			builder.Services.AddSingleton<MusicApiService>(new MusicApiService(baseUrl));
            builder.Services.AddSingleton<MusicHubViewModel>();
            builder.Services.AddTransient<MusicHub>();
			builder.AddAudio();

			return builder.Build();
        }
    }
}
