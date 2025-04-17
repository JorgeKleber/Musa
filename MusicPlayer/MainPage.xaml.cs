using Microsoft.Maui.Controls;
using MusicPlayer.Services;
using MusicPlayer.ViewModels;
using MusicPlayer.Views;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace MusicPlayer
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MusicApiService apiService)
		{
			InitializeComponent();
			BindingContext = new MainPageViewModel(apiService);
		}

		private void CarouselView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
		{
			var deslocamento = e.HorizontalOffset;
			ParallaxImage.TranslationX = 200 - (deslocamento * 0.5);
		}

	}
}