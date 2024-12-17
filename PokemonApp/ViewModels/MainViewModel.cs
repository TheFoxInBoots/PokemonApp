using CommunityToolkit.Mvvm.Input;

namespace PokemonApp.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {        

        [RelayCommand]
        async Task GotoGame() 
        {
            await Shell.Current.GoToAsync(nameof(GamePage));
        }
    }
}
