using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public record class PokemonJsonLeveling
{
    [JsonPropertyName("prof")]
    public int Proficiency { get; set; }

    [JsonPropertyName("STAB")]
    public int SameTypeAttackBonus { get; set; }

    [JsonPropertyName("ASI")]
    public int AbilityScoreIncrease { get; set; }

    [JsonPropertyName("exp")]
    public int Experience { get; set; }
}