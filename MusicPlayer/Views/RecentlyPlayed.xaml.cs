using MusicPlayer.Services;
using MusicPlayer.ViewModels;

namespace MusicPlayer.Views;

public partial class RecentlyPlayed : ContentView
{
	private readonly MusicApiService _musicApiService;
	private RecentlyPlayedViewModel _viewModel;

	public RecentlyPlayed() : this(Application.Current?.Handler?.MauiContext?.Services.GetService<MusicApiService>())
	{
		
	}

	public RecentlyPlayed(MusicApiService musicApiService)
	{
		InitializeComponent();
		_musicApiService = musicApiService;
		_viewModel = new RecentlyPlayedViewModel(musicApiService);
		BindingContext = _viewModel;
	}

	protected override async void OnParentSet()
	{
		base.OnParentSet();

		await _viewModel.LoadImages();
	}
}