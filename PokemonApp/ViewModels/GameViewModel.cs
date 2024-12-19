using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokemonApp.Models;
using PokemonApp.Services;
using System.Collections.ObjectModel;

namespace PokemonApp.ViewModels
{
    public partial class GameViewModel : BaseViewModel
    {
        private readonly GameService gameService;

        [ObservableProperty]
        private Pokemon displayedPokemon;

        [ObservableProperty]
        private int score;

        [ObservableProperty]
        private string statusMessage;

        [ObservableProperty]
        private int remainingTries;
               
        public GameViewModel(GameService gameService)
        {
            this.gameService = gameService;
            _ = LoadPokemons(); 
        }
        public ObservableCollection<ButtonState> ButtonStates => gameService.ButtonStates;

        [RelayCommand]
        public async Task LoadPokemons()
        {
            await gameService.InitializeGameAsync();
            DisplayedPokemon = gameService.CorrectPokemon;
            StatusMessage = string.Empty; 
            RemainingTries = 3;            
        }
        
        [RelayCommand]
        public void Guess(string guessedName)
        {
            if (StatusMessage == "Well done!") return; 

            var correct = gameService.Guess(guessedName);
            Score = gameService.Score;

            if (correct)
            {
                RemainingTries--;
                StatusMessage = "Well done!";
            }
            else
            {
                RemainingTries--; 

                if (!gameService.GameActive && gameService.ButtonStates.All(b => !b.IsEnabled))
                {
                    StatusMessage = "Out of luck!";
                }
            }
        }
    }
}
