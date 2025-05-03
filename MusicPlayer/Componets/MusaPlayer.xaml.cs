
using MusicPlayer.Services;
using MusicPlayer.ViewModels;
using Plugin.Maui.Audio;

namespace MusicPlayer.Componets;

public partial class MusaPlayer : ContentPage
{
	private readonly MusicApiService _service;

	public PlayerViewModel ViewModel { get; set; }

	public MusaPlayer(IAudioManager audioManager, MusicApiService service, PlayerViewModel viewModel)
	{
		InitializeComponent();


		ViewModel = viewModel;

		BindingContext = ViewModel;

		_service = service;
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

