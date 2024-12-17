using PokemonApp.ViewModels;

namespace PokemonApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
        }
    }
}
