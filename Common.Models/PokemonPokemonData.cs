using Common.Models.JsonClasses;
using System.Collections.Generic;

namespace Common.Models;

public record class PokemonPokemonData
{
    public int ArmorClass { get; set; }

    public List<string> Abilities { get; set; } = DefaultValues.ListStringDefault;

    public int HP { get; set; }

    public string? HiddenAbility { get; set; }

    public int HitDice { get; set; }

    public int MinimumFieldLevel { get; set; }

    public PokemonJsonPokemonMoves Moves { get; set; } = PokemonJsonPokemonMoves.Default;

    public double SpeciesRating { get; set; }

    public List<string>? Skills { get; set; }

    public PokemonType Type1 { get; set; }

    public PokemonType? Type2 { get; set; }

    public int? WalkSpeed { get; set; }

    public int? SwimSpeed { get; set; }

    public int? FlySpeed { get; set; }

    public int? ClimbSpeed { get; set; }

    public Dictionary<string, int> Attributes { get; set; } = DefaultValues.DictionaryIntDefault;

    public int Index { get; set; }

    public List<string>? Senses { get; set; }

    public string? Evolve { get; set; }

    public List<string>? SavingThrows { get; set; }

    public string Size { get; set; } = string.Empty;
}