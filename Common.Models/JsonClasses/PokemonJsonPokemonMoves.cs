using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public record class PokemonJsonPokemonMoves
{
    public static readonly PokemonJsonPokemonMoves Default = new();

    [JsonPropertyName("Level")]
    public Dictionary<string, List<string>>? LearnByLevelUp { get; set; }

    [JsonPropertyName("Starting Moves")]
    public List<string> StartingMoves { get; set; } = DefaultValues.ListStringDefault;

    [JsonPropertyName("TM")]
    public List<int>? LearnByTM { get; set; }
}