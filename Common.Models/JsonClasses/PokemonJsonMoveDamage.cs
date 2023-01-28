using Common.Models.DataClasses;
using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public record class PokemonJsonMoveDamage : IPokemonJsonType<MoveDamageData>
{
    public int Amount { get; set; }

    [JsonPropertyName("dice_max")]
    public int DiceMax { get; set; }

    public bool Move { get; set; }

    public MoveDamageData ToOutput(string input) => new()
    {
        Level = int.Parse(input),
        Amount = Amount,
        Move = Move,
        DiceMax = DiceMax
    };
}