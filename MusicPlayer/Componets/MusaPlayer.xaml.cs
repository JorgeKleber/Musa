
using MusicPlayer.Services;
using MusicPlayer.ViewModels;
using Plugin.Maui.Audio;

namespace MusicPlayer.Componets;

[QueryProperty(nameof(_musicId),"musicId")]
public partial class MusaPlayer : ContentPage
{
	private readonly MusicApiService _service;
	private int _musicId;

	public PlayerViewModel ViewModel { get; set; }

	public MusaPlayer(IAudioManager audioManager, MusicApiService service)
	{
		InitializeComponent();


		ViewModel = new PlayerViewModel(audioManager, service, _musicId);

		BindingContext = ViewModel;

		// Pega instância via DI
		_service = service;
		//this._musicId = _musicId;
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

