

using System.Text.Json.Serialization;

namespace PokemonApp.Models
{
    public class Pokemon
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string SpriteUrl
        {
            get
            {
                if (Id.HasValue)
                {
                    return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
                }
                return string.Empty;
            }
        }
    }
}
