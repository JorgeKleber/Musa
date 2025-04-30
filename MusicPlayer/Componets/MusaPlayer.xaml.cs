
using MusicPlayer.Services;
using MusicPlayer.ViewModels;
using Plugin.Maui.Audio;

namespace MusicPlayer.Componets;

public partial class MusaPlayer : ContentPage
{
	private readonly MusicApiService _service;
	private int _musicId;

	public PlayerViewModel ViewModel { get; set; }

	public MusaPlayer(IAudioManager audioManager, MusicApiService service, int musicId)
	{
		InitializeComponent();


		ViewModel = new PlayerViewModel(audioManager, service, musicId);

		BindingContext = ViewModel;

		// Pega instância via DI
		_service = service;
		_musicId = musicId;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		await ViewModel.LoadMusic();
		
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();

		ViewModel.FinishPlayer();
	}
}

