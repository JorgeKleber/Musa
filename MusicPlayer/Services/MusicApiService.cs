using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    public class MusicApiService
    {
		private readonly HttpClient _httpClient;

		public string BaseAddress { get; set; }

		public MusicApiService(string baseUrl)
		{
			BaseAddress = baseUrl;

			_httpClient = new HttpClient
			{
				BaseAddress = new Uri(baseUrl)
			};
		}

		public async Task<List<MusicInfo>> GetAllMusicsAsync()
		{
			var result = await _httpClient.GetFromJsonAsync<List<MusicInfo>>("/musics");
			return result ?? new List<MusicInfo>();
		}

		public async Task<MusicInfo?> GetMusicByIdAsync(int id)
		{
			var result = await _httpClient.GetFromJsonAsync<MusicInfo>($"/musics/{id}");
			return result;
		}

		public async Task<List<ImageInfo>> GetAllImages()
		{
			var result = await _httpClient.GetFromJsonAsync<List<ImageInfo>>("/images");
			return result ?? new List<ImageInfo>();
		}
	}
}
