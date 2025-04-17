using CommunityToolkit.Mvvm.ComponentModel;
using MusicPlayer.Models;
using MusicPlayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModels
{
    public partial class RecentlyPlayedViewModel : ObservableObject
	{
		private readonly MusicApiService _service;

		[ObservableProperty]
		private ImageInfo _card1;
		[ObservableProperty]
		private ImageInfo _card2;
		[ObservableProperty]
		private ImageInfo _card3;
		[ObservableProperty]
		private ImageInfo _card4;
		[ObservableProperty]
		private ImageInfo _card5;
		[ObservableProperty]
		private ImageInfo _card6;
		[ObservableProperty]
		private ImageInfo _card7;

		[ObservableProperty]
		private List<ImageInfo> _images;

		public RecentlyPlayedViewModel(MusicApiService service)
		{
			_service = service;
		}

		public async Task LoadImages()
		{
			var list = await _service.GetAllImages();
			Images = list.ToList();

			Card1 = Images[0];
			Card2 = Images[1];
			Card3 = Images[2];
			Card4 = Images[3];
			Card5 = Images[4];
			Card6 = Images[5];
			Card7 = Images[6];
		}
	}
}
