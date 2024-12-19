using PokemonApp.Models;
using System.Collections.ObjectModel;

namespace PokemonApp.Services
{
    public class GameService
    {
        private readonly PokemonService pokemonService;
        private int tries;
        private bool gameActive;
        public int Score { get; private set; }
        public Pokemon CorrectPokemon { get; private set; }
        public ObservableCollection<ButtonState> ButtonStates { get; private set; } = new();

        public GameService(PokemonService pokemonService)
        {
            this.pokemonService = pokemonService;
        }

        public async Task InitializeGameAsync()
        {
            var pokemonList = await pokemonService.GetRandomPokemons();
            CorrectPokemon = pokemonList[new Random().Next(pokemonList.Count)];
            ButtonStates.Clear();
            foreach (var pokemon in pokemonList)
            {
                ButtonStates.Add(new ButtonState { Name = pokemon.Name, Color = "#ffcb05" });
            }
            tries = 0;
            gameActive = true;
        }

        public bool Guess(string guessedName)
        {
            if (!gameActive) return false;
            var index = ButtonStates.Select(p => p.Name).ToList().IndexOf(guessedName);
            if (index == -1 || tries >= 3) return false;
            if (guessedName == CorrectPokemon.Name)
            {
                ButtonStates[index].Color = "Green";
                Score++;
                gameActive = false;
                foreach (var buttonState in ButtonStates)
                {
                    buttonState.IsEnabled = false;
                }
                return true;
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
                return false;
            }
        }

        public bool GameActive => gameActive;
    }
}
