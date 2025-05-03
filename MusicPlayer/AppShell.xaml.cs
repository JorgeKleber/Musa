using MusicPlayer.Componets;

namespace MusicPlayer
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MusaPlayer), typeof(MusaPlayer));
		}
    }
}
