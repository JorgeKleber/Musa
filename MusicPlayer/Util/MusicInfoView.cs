using MusicPlayer.Models;
using MusicPlayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Util
{
    public class MusicInfoView : MusicInfo
	{
		public string CoverUrlAbsolute { get; set; }

		public MusicInfoView(MusicInfo baseInfo, MusicApiService service)
		{
			Id = baseInfo.Id;
			Title = baseInfo.Title;
			Artist = baseInfo.Artist;
			Album = baseInfo.Album;
			FileName = baseInfo.FileName;
			CoverUrl = baseInfo.CoverUrl;
			StreamUrl = baseInfo.StreamUrl;
			// Monta a URL completa:
			// baseClient e BaseAddress => ex.: http://10.0.2.2:5000
			// m.CoverUrl => ex.: /images/cover1.jpg
			CoverUrlAbsolute = new Uri(new Uri(service.BaseAddress), baseInfo.CoverUrl).ToString();
		}
	}
}
