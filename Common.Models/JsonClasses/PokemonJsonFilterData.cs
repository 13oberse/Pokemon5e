using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public record class PokemonJsonFilterData
{
    public int Index { get; set; }

    public List<string> Type { get; set; } = DefaultValues.ListStringDefault;

    [JsonPropertyName("SR")]
    public decimal SpeciesRating { get; set; }

    [JsonPropertyName("MIN LVL FD")]
    public int MinimumFieldLevel { get; set; }
}