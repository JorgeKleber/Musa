using CommunityToolkit.Mvvm.ComponentModel;
using MusicPlayer.Services;
using MusicPlayer.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModels
{
	public partial class MainPageViewModel : ObservableObject
	{
		private readonly MusicApiService _service;

		[ObservableProperty]
		private List<MusicInfoView> _musics;

		public MainPageViewModel(MusicApiService service)
		{
			_service = service;
			Musics = new List<MusicInfoView>();
		}

		public async Task LoadMusics()
		{
			var list = await _service.GetAllMusicsAsync();
			// Convert para MusicInfoView para termos a URL completa de imagem
			Musics = list.Select(m => new MusicInfoView(m, _service)).ToList();
		}
	}
}
