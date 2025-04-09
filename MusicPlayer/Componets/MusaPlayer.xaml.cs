
using MusicPlayer.Services;

namespace MusicPlayer.Componets;

public partial class MusaPlayer : ContentPage
{
	private readonly MusicApiService _service;
	private int _musicId;

	public MusaPlayer(MusicApiService service, int musicId)
	{
		InitializeComponent();

		// Pega instância via DI
		_service = service;
		_musicId = musicId;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await LoadMusicDetail(_musicId);
	}

	private async Task LoadMusicDetail(int id)
	{
		var music = await _service.GetMusicByIdAsync(id);
		if (music == null) return;

		TitleLabel.Text = music.Title;
		ArtistLabel.Text = music.Artist;
		AlbumLabel.Text = music.Album;

		// URL completa da capa:
		var coverUrlAbsolute = new Uri(new Uri(_service.BaseAddress), music.CoverUrl).ToString();
		CoverImage.Source = coverUrlAbsolute;

		// URL completa do streaming:
		var streamUrlAbsolute = new Uri(new Uri(_service.BaseAddress), music.StreamUrl).ToString();

		AudioPlayer.Source = streamUrlAbsolute;
	}

	//private async void OnSearchClicked(object sender, EventArgs e)
	//{
	//	var query = SearchEntry.Text;
	//	if (string.IsNullOrWhiteSpace(query))
	//		return;

	//	var httpClient = new HttpClient();
	//	var url = $"https://api.deezer.com/search?q={Uri.EscapeDataString(query)}";

	//	try
	//	{
	//		var result = await httpClient.GetFromJsonAsync<DeezerSearchResult>(url);
	//		MusicList.ItemsSource = result?.data ?? new List<Track>();
	//	}
	//	catch (Exception ex)
	//	{
	//		await DisplayAlert("Error", ex.Message, "OK");
	//	}
	//}

	//private void OnItemSelected(object sender, SelectionChangedEventArgs e)
	//{
	//	if (e.CurrentSelection.FirstOrDefault() is Track selectedTrack)
	//	{
	//		if (!string.IsNullOrEmpty(selectedTrack.preview))
	//		{
	//			AudioPlayer.Source = selectedTrack.preview;
	//			AudioPlayer.Play();
	//		}
	//		else
	//		{
	//			DisplayAlert("Unavailable", "Preview not available for this track.", "OK");
	//		}
	//	}

	//	// Clear selection
	//	((CollectionView)sender).SelectedItem = null;
	//}
}

