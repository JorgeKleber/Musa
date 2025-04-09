

namespace MusicPlayer.Componets;

public partial class TitleCard : ContentView
{

	public static readonly BindableProperty ImageSourceProperty =
			BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(TitleCard), default(ImageSource), propertyChanged: OnImageSourceChanged);

	public static readonly BindableProperty TitleProperty =
			BindableProperty.Create(nameof(Title), typeof(string), typeof(TitleCard), "Desconhecido", propertyChanged: OnTitleChanged);

	public static readonly BindableProperty WidthDefinitionProperty =
			BindableProperty.Create(nameof(WidthDefinition), typeof(double), typeof(TitleCard), defaultValue: 180.0, propertyChanged: OnWidthChanged);

	public static readonly BindableProperty HeightDefinitionProperty =
			BindableProperty.Create(nameof(HeightDefinition), typeof(double), typeof(TitleCard), defaultValue: 180.0, propertyChanged: OnHeightChanged);

	public static readonly BindableProperty VisibilityProperty =
		BindableProperty.Create(nameof(VisibilityFlag), typeof(bool), typeof(TitleCard), defaultValue: true, propertyChanged: OnVisibilityChanged);


	public ImageSource ImageSource
	{
		get => (ImageSource)GetValue(ImageSourceProperty);
		set => SetValue(ImageSourceProperty, value);
	}

	public string Title
	{
		get => (string)GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}

	public double WidthDefinition
	{
		get => (double)GetValue(WidthDefinitionProperty);
		set => SetValue(WidthDefinitionProperty, value);
	}

	public double HeightDefinition
	{
		get => (double)GetValue(HeightDefinitionProperty);
		set => SetValue(HeightDefinitionProperty, value);
	}

	public bool VisibilityFlag
	{
		get => (bool)GetValue(VisibilityProperty);
		set => SetValue(VisibilityProperty, value);
	}

	public TitleCard()
	{
		InitializeComponent();
	}

	private static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var control = (TitleCard)bindable;
		control.TitleImage.Source = (ImageSource)newValue;
	}

	private static void OnTitleChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var control = (TitleCard)bindable;
		control.ArtistName.Text = newValue?.ToString();
	}

	private static void OnWidthChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var control = (TitleCard)bindable;
		control.MainGrid.WidthRequest = (double)newValue;
	}

	private static void OnHeightChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var control = (TitleCard)bindable;
		control.MainGrid.HeightRequest = (double)newValue;
	}

	private static void OnVisibilityChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var control = (TitleCard)bindable;
		control.TitleFlag.IsVisible = (bool)newValue;
	}
}