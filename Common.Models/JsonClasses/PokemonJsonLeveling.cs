using Common.Models.DataClasses;
using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public record class PokemonJsonLeveling : IPokemonJsonType<LevelingData>
{
    [JsonPropertyName("prof")]
    public int Proficiency { get; init; }

    [JsonPropertyName("STAB")]
    public int SameTypeAttackBonus { get; init; }

    [JsonPropertyName("ASI")]
    public int AbilityScoreIncrease { get; init; }

    [JsonPropertyName("exp")]
    public int Experience { get; init; }

    public LevelingData ToOutput(string input) => new()
    {
        Level = int.Parse(input),
        Experience = Experience,
        Proficiency = Proficiency,
        AbilityScoreIncrease = AbilityScoreIncrease,
        SameTypeAttackBonus = SameTypeAttackBonus
    };
}