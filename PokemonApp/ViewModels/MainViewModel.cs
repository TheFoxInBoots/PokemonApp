using CommunityToolkit.Mvvm.Input;

namespace PokemonApp.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly GameViewModel gameViewModel;

        public MainViewModel(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
        }

        [RelayCommand]
        public async Task GotoGame() 
        {
            await Shell.Current.GoToAsync(nameof(GamePage));
        }  
    }
}
