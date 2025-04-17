using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
	public class ImageInfo
	{
		const string baseUrl = "http://192.168.3.11:5000";
		private string _imageUrl;

		public int IdImage { get; set; }
		public string Artista { get; set; }
		public string ImageUrl 
		{ 
			get => _imageUrl;
			set => _imageUrl = $"{baseUrl}{value}";
		}
	}
}
