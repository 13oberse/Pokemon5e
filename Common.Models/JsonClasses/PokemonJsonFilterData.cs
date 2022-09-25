using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public record class PokemonJsonFilterData
{
    public int Index { get; set; }

    public List<string> Type { get; set; } = DefaultValues.ListStringDefault;

    [JsonPropertyName("SR")]
    public string SpeciesRating { get; set; } = string.Empty;

    [JsonPropertyName("MIN LVL FD")]
    public string MinimumFieldLevel { get; set; } = string.Empty;
}