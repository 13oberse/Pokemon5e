using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public class PokemonJsonMove
{
    public Dictionary<string, PokemonJsonMoveDamage> Damage { get; set; } = DefaultValues.DictionaryMoveDamageDefault;

    public string Description { get; set; } = string.Empty;

    public string Duration { get; set; } = string.Empty;

    [JsonPropertyName("Move Power")]
    public List<string> MovePower { get; set; } = DefaultValues.ListStringDefault;
}