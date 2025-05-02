using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicPlayer.Componets;
using MusicPlayer.Services;
using MusicPlayer.Util;
using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicPlayer.ViewModels
{
	public partial class MusicHubViewModel : ObservableObject
	{

		private readonly MusicApiService _musicApiService;
		private readonly IAudioManager _audioManager;

		
		[ObservableProperty] List<MusicInfoView> _musics;
		[ObservableProperty] MusicInfoView _musicsSelected;

		public MusicHubViewModel(MusicApiService musicApiService, IAudioManager audioManager)
		{
			_musicApiService = musicApiService;
			_audioManager = audioManager;
		}

		[RelayCommand]
		private async Task SelectItem()
		{
			if (MusicsSelected == null)
				return;

			await Shell.Current.GoToAsync($"{nameof(MusaPlayer)}?musicId={MusicsSelected.Id}");
		}

		public async Task LoadMusics()
		{
			var list = await _musicApiService.GetAllMusicsAsync();
			// Convert para MusicInfoView para termos a URL completa de imagem
			Musics = list.Select(m => new MusicInfoView(m, _musicApiService)).ToList();
		}
	}
}
