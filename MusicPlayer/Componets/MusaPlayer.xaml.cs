using MusicPlayer.Models;
using System.Net.Http.Json;

namespace MusicPlayer.Componets;

public partial class MusaPlayer : ContentPage
{
	public MusaPlayer()
	{
		InitializeComponent();
	}
	private async void OnSearchClicked(object sender, EventArgs e)
	{
		var query = SearchEntry.Text;
		if (string.IsNullOrWhiteSpace(query))
			return;

		var httpClient = new HttpClient();
		var url = $"https://api.deezer.com/search?q={Uri.EscapeDataString(query)}";

		try
		{
			var result = await httpClient.GetFromJsonAsync<DeezerSearchResult>(url);
			MusicList.ItemsSource = result?.data ?? new List<Track>();
		}
		catch (Exception ex)
		{
			await DisplayAlert("Error", ex.Message, "OK");
		}
	}

	private void OnItemSelected(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is Track selectedTrack)
		{
			if (!string.IsNullOrEmpty(selectedTrack.preview))
			{
				AudioPlayer.Source = selectedTrack.preview;
				AudioPlayer.Play();
			}
			else
			{
				DisplayAlert("Unavailable", "Preview not available for this track.", "OK");
			}
		}

		// Clear selection
		((CollectionView)sender).SelectedItem = null;
	}
}

