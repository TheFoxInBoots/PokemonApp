using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokemonApp.Models;
using PokemonApp.Services;
using System.Collections.ObjectModel;

namespace PokemonApp.ViewModels
{
    public partial class GameViewModel : BaseViewModel
    {
        private readonly PokemonService pokemonService;
        private int tries;
        private Pokemon correctPokemon;
        private bool gameActive;

        [ObservableProperty]
        ObservableCollection<Pokemon> pokemons = new ObservableCollection<Pokemon>();

        [ObservableProperty]
        Pokemon displayedPokemon;

        [ObservableProperty]
        ObservableCollection<ButtonState> buttonStates = new ObservableCollection<ButtonState>();

        [ObservableProperty]
        int score = 0;

        public GameViewModel(PokemonService pokemonService)
        {
            this.pokemonService = pokemonService;
            _ = LoadPokemons(); // Load Pokemons when the view model is initialized
        }

        [RelayCommand]
        public async Task LoadPokemons()
        {
            Pokemons.Clear();
            var pokemonList = await pokemonService.GetRandomPokemons();
            foreach (var pokemon in pokemonList)
            {
                Pokemons.Add(pokemon);
            }

            // Select a random Pokémon to display
            correctPokemon = pokemonList[new Random().Next(pokemonList.Count)];
            DisplayedPokemon = correctPokemon;

            // Initialize button states
            ButtonStates.Clear();
            foreach (var pokemon in pokemonList)
            {
                ButtonStates.Add(new ButtonState { Name = pokemon.Name, Color = "#ffcb05" });
            }

            tries = 0;
            gameActive = true;
        }

        [RelayCommand]
        public void Guess(string guessedName)
        {
            if (!gameActive) return;
            var index = ButtonStates.Select(p => p.Name).ToList().IndexOf(guessedName);
            if (index == -1 || tries >= 3) return;
            if (guessedName == correctPokemon.Name)
            {
                ButtonStates[index].Color = "Green";
                Score++;
                gameActive = false;
                foreach (var buttonState in ButtonStates)
                {
                    buttonState.IsEnabled = false;
                }
            }
            else
            {
                ButtonStates[index].Color = "Red";
                tries++;
                if (tries >= 3)
                {
                    gameActive = false;
                    foreach (var buttonState in ButtonStates)
                    {
                        buttonState.IsEnabled = false;
                    }
                }
            }
        }
    }
}
