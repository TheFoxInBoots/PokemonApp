using CommunityToolkit.Mvvm.ComponentModel;

namespace PokemonApp.Models
{
    public partial class ButtonState : ObservableObject
    {
        [ObservableProperty]
        string name;

        [ObservableProperty]
        string color;

        [ObservableProperty]
        bool isEnabled;
    }
}
