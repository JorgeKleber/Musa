using MusicPlayer.Componets;
using MusicPlayer.Models;
using MusicPlayer.Services;
using MusicPlayer.ViewModels;
using Plugin.Maui.Audio;

namespace MusicPlayer.Views;

public partial class SearchPage : ContentView
{
	public SearchPage() : this(Application.Current?.Handler?.MauiContext?.Services.GetService<SearchPageViewModel>())
	{

	}


	public SearchPage(SearchPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}