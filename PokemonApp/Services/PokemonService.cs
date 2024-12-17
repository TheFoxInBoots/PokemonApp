using PokemonApp.Models;
using System.Net.Http.Json;

namespace PokemonApp.Services
{
    public class PokemonService
    {
        HttpClient httpClient;      

        public PokemonService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Pokemon>> GetRandomPokemons(int count = 6, int minId = 1, int maxId = 579) 
        { 
            var random = new Random();
            List<Pokemon> fetchedPokemons = new List<Pokemon>();

            for (int i = 0; i < count; i++) 
            { 
                int randomId = random.Next(minId, maxId + 1); 
                Pokemon pokemon = await GetPokemonAsync(randomId); 
                if ( pokemon != null)
                {
                    fetchedPokemons.Add(pokemon);
                }
            } 
            return fetchedPokemons; 
        }

        private async Task<Pokemon> GetPokemonAsync(int id)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon-species/{id}";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var pokemon = await response.Content.ReadFromJsonAsync<Pokemon>();
                return pokemon;
            }
            return null;
        }


    }


}
