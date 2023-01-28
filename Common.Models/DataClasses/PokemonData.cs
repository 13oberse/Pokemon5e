using Common.Models.JsonClasses;
using System.Collections.Generic;

namespace Common.Models.DataClasses;

public record PokemonData
{
    public string Name { get; init; } = string.Empty;

    public int Index { get; init; }

    public int HP { get; init; }

    public int HitDice { get; init; }

    public int ArmorClass { get; init; }

    public int MinimumFieldLevel { get; init; }

    public double SpeciesRating { get; init; }

    public PokemonType Type1 { get; init; }

    public PokemonType? Type2 { get; init; }

    public List<string> Abilities { get; init; } = DefaultValues.ListStringDefault;

    public string? HiddenAbility { get; init; }

    public List<SerializableKeyValuePair<PokemonAbilityScore, int>> Attributes { get; init; } = DefaultValues.AbilityScoreIntListDefault;

    public PokemonJsonPokemonMoves Moves { get; init; } = PokemonJsonPokemonMoves.Default;

    public List<string>? Skills { get; init; }

    public int? WalkSpeed { get; init; }

    public int? SwimSpeed { get; init; }

    public int? FlySpeed { get; init; }

    public int? ClimbSpeed { get; init; }

    public List<string>? Senses { get; init; }

    public string? Evolve { get; init; }

    public PokemonAbilityScore? SavingThrows { get; init; }

    public PokemonSize Size { get; init; }

    public PokemonGender? Gender { get; init; }

    public PokedexExtraData PokedexExtraData { get; init; } = PokedexExtraData.Default;
}