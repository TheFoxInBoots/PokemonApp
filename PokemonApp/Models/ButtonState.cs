using CommunityToolkit.Mvvm.ComponentModel;

namespace PokemonApp.ViewModels
{
    public partial class ButtonState : ObservableObject
    {
        [ObservableProperty]
        string name;

        [ObservableProperty]
        string color = "#ffcb05";

        [ObservableProperty]
        bool isEnabled;
    }
}
