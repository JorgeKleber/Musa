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
	public class SearchPageViewModel : INotifyPropertyChanged
	{
		private readonly MusicApiService _service;
		public event PropertyChangedEventHandler PropertyChanged;

		private List<MusicInfoView> _musics;
		public List<MusicInfoView> Musics
		{
			get => _musics;
			set
			{
				_musics = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Musics)));
			}
		}

		public SearchPageViewModel(MusicApiService service)
		{
			_service = service;
			_musics = new List<MusicInfoView>();
		}

		public async Task LoadMusics()
		{
			var list = await _service.GetAllMusicsAsync();
			// Convert para MusicInfoView para termos a URL completa de imagem
			Musics = list.Select(m => new MusicInfoView(m, _service)).ToList();
		}
	}
}