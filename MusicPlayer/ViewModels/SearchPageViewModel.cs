using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicPlayer.Componets;
using MusicPlayer.Services;
using MusicPlayer.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicPlayer.ViewModels
{
	public partial class SearchPageViewModel : ObservableObject
	{

		[ObservableProperty] private MusicApiService _service;

		[ObservableProperty] private List<MusicInfoView> _musics;
		[ObservableProperty] private MusicInfoView _musicsSelected;
		[ObservableProperty] private string _searchText;

		public SearchPageViewModel(MusicApiService service)
		{
			Service = service;
			Musics = new List<MusicInfoView>();
		}

		public async Task LoadMusics()
		{
			var list = await _service.GetAllMusicsAsync();
			Musics = list.Select(m => new MusicInfoView(m, _service)).ToList();
		}

		[RelayCommand]
		public async Task Search(string teste)
		{
			if (string.IsNullOrWhiteSpace(SearchText))
				return;

			if (!string.IsNullOrWhiteSpace(SearchText))
			{
				var result = await _service.GetSearchResults(SearchText);

				if (result != null)
				{
					await MainThread.InvokeOnMainThreadAsync(() =>
					{
						Musics = result.Select(m => new MusicInfoView(m, _service)).ToList();
					});
				}
				else
				{
					Musics = new List<MusicInfoView>();
				}
			}
		}

		[RelayCommand]
		public async Task SelectItem()
		{
			if (MusicsSelected == null)
				return;
			await Shell.Current.GoToAsync($"{nameof(MusaPlayer)}?musicId={MusicsSelected.Id}");
		}
	}
}