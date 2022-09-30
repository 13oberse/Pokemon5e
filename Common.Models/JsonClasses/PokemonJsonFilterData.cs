using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public record class PokemonJsonFilterData : IPokemonJsonType<PokemonFilterData>
{
    public int Index { get; set; }

    [JsonPropertyName("Type")]
    public List<string> Types { get; set; } = DefaultValues.ListStringDefault;

    [JsonPropertyName("SR")]
    public decimal SpeciesRating { get; set; }

    [JsonPropertyName("MIN LVL FD")]
    public int MinimumFieldLevel { get; set; }

    public PokemonFilterData ToOutput() => new PokemonFilterData
    {
        Index = Index,
        SpeciesRating = SpeciesRating,
        MinimumFieldLevel = MinimumFieldLevel,
        Type1 = Types[0].GetPokemonType(),
        Type2 = Types.Count > 1 ? Types[1].GetPokemonType() : null
    };
}