using MusicPlayer.Services;
using MusicPlayer.ViewModels;
using Plugin.Maui.Audio;

namespace MusicPlayer.Views;

public partial class MusicHub : ContentView
{

	public MusicHubViewModel ViewModel { get; set; }

	public MusicHub() : this(Application.Current?.Handler?.MauiContext?.Services.GetService<MusicHubViewModel>())
	{

	}

	public MusicHub(MusicHubViewModel viewModel)
	{
		InitializeComponent();
		ViewModel = viewModel;
		BindingContext = ViewModel;
	}

	protected override async void OnParentSet()
	{
		base.OnParentSet();
		await ViewModel.LoadMusics();
	}
}