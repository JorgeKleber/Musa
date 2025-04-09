using MusicPlayer.Componets;
using MusicPlayer.Models;
using MusicPlayer.Services;
using MusicPlayer.ViewModels;

namespace MusicPlayer.Views;

public partial class SearchPage : ContentView
{

	private readonly MusicApiService _musicApiService;
	private SearchPageViewModel _viewModel;
	public SearchPage() : this(Application.Current?.Handler?.MauiContext?.Services.GetService<MusicApiService>())
	{

	}


	public SearchPage(MusicApiService musicApiService)
	{
		InitializeComponent();

		_musicApiService = musicApiService;
		_viewModel = new SearchPageViewModel(_musicApiService);
		BindingContext = _viewModel;
	}


	protected override async void OnParentSet()
	{
		base.OnParentSet();
		await _viewModel.LoadMusics();
	}

	//protected override async void OnAppearing()
	//{
	//	base.OnAppearing();
	//	await _viewModel.LoadMusics();
	//}

	private void OnMusicSelected(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.Count > 0)
		{
			var selectedMusic = e.CurrentSelection.FirstOrDefault() as MusicInfo;
			if (selectedMusic != null)
			{
				// Navegar para página de detalhes, por exemplo
				Navigation.PushAsync(new MusaPlayer(_musicApiService, selectedMusic.Id));

				// Reseta seleção para não ficar marcada
				MusicsCollectionView.SelectedItem = null;
			}
		}
	}

}