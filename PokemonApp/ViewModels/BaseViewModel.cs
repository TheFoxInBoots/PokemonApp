using CommunityToolkit.Mvvm.ComponentModel;

namespace PokemonApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? title;
    }
}
