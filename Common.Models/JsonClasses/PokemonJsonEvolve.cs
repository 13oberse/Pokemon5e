using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public record class PokemonJsonEvolve
{
    public List<string> Into { get; set; } = DefaultValues.ListStringDefault;

    [JsonPropertyName("current_stage")]
    public int CurrentStage { get; set; }

    [JsonPropertyName("total_stages")]
    public int TotalStages { get; set; }

    public int Points { get; set; }

    public int Level { get; set; }
}