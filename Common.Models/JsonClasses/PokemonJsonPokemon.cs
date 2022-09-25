using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public record class PokemonJsonPokemon
{
    [JsonPropertyName("AC")]
    public int ArmorClass { get; set; }

    public List<string> Abilities { get; set; } = DefaultValues.ListStringDefault;

    public int HP { get; set; }

    [JsonPropertyName("Hidden Ability")]
    public string? HiddenAbility { get; set; }

    [JsonPropertyName("Hit Dice")]
    public int HitDice { get; set; }

    [JsonPropertyName("MIN LVL FD")]
    public int MinimumFieldLevel { get; set; }

    public PokemonJsonPokemonMoves Moves { get; set; } = PokemonJsonPokemonMoves.Default;

    [JsonPropertyName("SR")]
    public double SpeciesRating { get; set; }

    [JsonPropertyName("Skill")]
    public List<string>? Skills { get; set; }

    public List<string> Type { get; set; } = DefaultValues.ListStringDefault;

    [JsonPropertyName("WSp")]
    public int? WalkSpeed { get; set; }

    [JsonPropertyName("Ssp")]
    public int? SwimSpeed { get; set; }

    [JsonPropertyName("Fsp")]
    public int? FlySpeed { get; set; }

    [JsonPropertyName("Climbing Speed")]
    public int? ClimbSpeed { get; set; }

    public Dictionary<string, int> Attributes { get; set; } = DefaultValues.DictionaryIntDefault;

    public int Index { get; set; }

    public List<string>? Senses { get; set; }

    public string? Evolve { get; set; }

    [JsonPropertyName("saving_throws")]
    public List<string>? SavingThrows { get; set; }

    public string Size { get; set; } = string.Empty;
}