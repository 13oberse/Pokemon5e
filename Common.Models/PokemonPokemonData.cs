using Common.Models.JsonClasses;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models;

public record class PokemonPokemonData
{
    public int ArmorClass { get; init; }

    public List<string> Abilities { get; init; } = DefaultValues.ListStringDefault;

    public int HP { get; init; }

    public string? HiddenAbility { get; init; }

    public int HitDice { get; init; }

    public int MinimumFieldLevel { get; init; }

    public PokemonJsonPokemonMoves Moves { get; init; } = PokemonJsonPokemonMoves.Default;

    public double SpeciesRating { get; init; }

    public List<string>? Skills { get; init; }

    public PokemonType Type1 { get; init; }

    public PokemonType? Type2 { get; init; }

    public int? WalkSpeed { get; init; }

    public int? SwimSpeed { get; init; }

    public int? FlySpeed { get; init; }

    public int? ClimbSpeed { get; init; }

    public Dictionary<string, int> Attributes { get; init; } = DefaultValues.DictionaryIntDefault;

    public int Index { get; init; }

    public List<string>? Senses { get; init; }

    public string? Evolve { get; init; }

    public List<string>? SavingThrows { get; init; }

    public string Size { get; init; } = string.Empty;

    //I can't figure out how to avoid putting it here
    [JsonIgnore]
    public bool ShowHide { get; set; }
}