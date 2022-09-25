using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public record class PokemonJsonMoveDamage
{
    public int Amount { get; set; }

    [JsonPropertyName("dice_max")]
    public int DiceMax { get; set; }

    public bool Move { get; set; }
}