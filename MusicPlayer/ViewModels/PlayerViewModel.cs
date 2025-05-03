using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicPlayer.Models;
using MusicPlayer.Services;
using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModels
{
	[QueryProperty(nameof(MusicId), "musicId")]
	public partial class PlayerViewModel : ObservableObject
	{
		private readonly IAudioManager _audioManager;
		private AsyncAudioPlayer _player;
		private CancellationTokenSource? _cts;
		private IDispatcherTimer _timer;
		private readonly MusicApiService _service;
		[ObservableProperty]
		private int musicId;
		private bool isPlaying = false;


		// --- Propriedades de UI ---
		[ObservableProperty] private MusicInfo _musicInfo;
		[ObservableProperty] private double progress;
		[ObservableProperty] private string albumCover;// = "placeholder_album.png";

		// Cores personalizáveis
		public Color ProgressColor { get; set; } = Colors.DeepSkyBlue;
		public Color ProgressBackgroundColor { get; set; } = Colors.LightGray;

		// Ícones
		public ImageSource PlayPauseIcon => _player?.IsPlaying == true ? "pause.png" : "play.png";
		public ImageSource LikeIcon => _liked ? "like_filled.png" : "like_outline.png";
		public ImageSource DislikeIcon => _disliked ? "dislike_filled.png" : "dislike_outline.png";
		public ImageSource FavoriteIcon => _favorited ? "fav_filled.png" : "fav_outline.png";

		private bool _liked, _disliked, _favorited;

		public PlayerViewModel(IAudioManager audioManager, MusicApiService service)
		{

			_service = service;
			_audioManager = audioManager;
		}

		public async Task LoadMusic()
		{
			MusicInfo = await _service.GetMusicByIdAsync(MusicId).ConfigureAwait(false);
			AlbumCover = _service.BaseAddress + MusicInfo.CoverUrl;
			_cts = new CancellationTokenSource();

			string musicUrl = _service.BaseAddress + MusicInfo.StreamUrl;

			var httpObj = new HttpClient();
			var musicStream = await httpObj.GetStreamAsync(musicUrl).ConfigureAwait(false);

			_player = _audioManager.CreateAsyncPlayer(musicStream);

			isPlaying = true;

			_timer = Application.Current.Dispatcher.CreateTimer();
			_timer.Interval = TimeSpan.FromMilliseconds(500);
			_timer.Tick += (_, _) => Progress = _player.CurrentPosition / _player.Duration;
			_timer.Start();

			await _player.PlayAsync(_cts.Token).ContinueWith(task =>
			{
				if (task.IsFaulted)
				{
					Console.WriteLine($"Erro: {task.Exception.Message}");
				}
			});
		}

		[RelayCommand]
		private void PlayPause()
		{
			if (isPlaying)
			{
				isPlaying = false;
				_player.Stop();
			}
			else
			{
				_player.PlayAsync(_cts.Token);
			}

			OnPropertyChanged(nameof(PlayPauseIcon));
		}

		public void FinishPlayer()
		{
			_cts?.Cancel();
			_cts?.Dispose();
			_player?.Stop();
			_player?.Dispose();
			_player = null;
			_timer?.Stop();
			_timer = null;
			_cts = null;
		}

		[RelayCommand] private void Next() => LoadMusic();
		[RelayCommand] private void Previous() => LoadMusic();

		[RelayCommand]
		private void Like()
		{
			_liked = !_liked; _disliked = false;
			OnPropertyChanged(nameof(LikeIcon));
			OnPropertyChanged(nameof(DislikeIcon));
		}

		[RelayCommand]
		private void Dislike()
		{
			_disliked = !_disliked; _liked = false;
			OnPropertyChanged(nameof(LikeIcon));
			OnPropertyChanged(nameof(DislikeIcon));
		}

		[RelayCommand]
		private void Favorite()
		{
			_favorited = !_favorited;
			OnPropertyChanged(nameof(FavoriteIcon));
		}

		// --- Helpers ---
		//private void LoadTrack(int step)
		//{
		//	// Sua lógica de playlist aqui…
		//	_player.Stop();
		//	_player.SetStream(GetStream("next-track.mp3"));
		//	_player.Play();
		//	OnPropertyChanged(nameof(PlayPauseIcon));
		//}

	}
}
