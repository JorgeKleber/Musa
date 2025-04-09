using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class MusicInfo
    {
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Artist { get; set; } = string.Empty;
		public string Album { get; set; } = string.Empty;
		public string FileName { get; set; } = string.Empty;
		public string CoverUrl { get; set; } = string.Empty; // Ex: /images/cover1.jpg
		public string StreamUrl { get; set; } = string.Empty; // Ex: /stream/audio/song1.mp3
	}
}
