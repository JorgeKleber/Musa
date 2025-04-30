using MusicPlayer.Componets;
using MusicPlayer.Models;
using MusicPlayer.Services;
using MusicPlayer.ViewModels;
using Plugin.Maui.Audio;

namespace MusicPlayer.Views;

public partial class SearchPage : ContentView
{

	private readonly MusicApiService _musicApiService;
	private readonly IAudioManager _audioManager;
	private SearchPageViewModel _viewModel;
	public SearchPage() : this(Application.Current?.Handler?.MauiContext?.Services.GetService<MusicApiService>(), Application.Current?.Handler?.MauiContext?.Services.GetService<IAudioManager>())
	{

	}


	public SearchPage(MusicApiService musicApiService, IAudioManager audioManager)
	{
		InitializeComponent();

		_musicApiService = musicApiService;
		_audioManager = audioManager;
		_viewModel = new SearchPageViewModel(_musicApiService);
		BindingContext = _viewModel;
	}


	protected override async void OnParentSet()
	{
		base.OnParentSet();
		await _viewModel.LoadMusics();
	}

	private void OnMusicSelected(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.Count > 0)
		{
			var selectedMusic = e.CurrentSelection.FirstOrDefault() as MusicInfo;
			if (selectedMusic != null)
			{
				// Navegar para página de detalhes, por exemplo
				Navigation.PushAsync(new MusaPlayer(_audioManager,_musicApiService, selectedMusic.Id));

				// Reseta seleção para não ficar marcada
				MusicsCollectionView.SelectedItem = null;
			}
		}
	}

}