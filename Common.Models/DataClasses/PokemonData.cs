using Common.Models.JsonClasses;
using System;
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

    public PokemonMoveData Moves { get; init; } = PokemonMoveData.Default;

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

    public PokemonData MakeNewWithExtra(Dictionary<string, PokemonJsonPokedexExtra> pokedexExtras, Dictionary<string, PokemonGender> genders) => new()
    {
        Abilities = Abilities,
        Attributes = Attributes,
        Evolve = Evolve,
        Gender = genders.TryGetValue(Name, out var gender) ? gender : null,
        Index = Index,
        Moves = Moves,
        Name = Name,
        Senses = Senses,
        Size = Size,
        Skills = Skills,
        Type1 = Type1,
        Type2 = Type2,
        ArmorClass = ArmorClass,
        ClimbSpeed = ClimbSpeed,
        FlySpeed = FlySpeed,
        HiddenAbility = HiddenAbility,
        HitDice = HitDice,
        HP = HP,
        SavingThrows = SavingThrows,
        SpeciesRating = SpeciesRating,
        SwimSpeed = SwimSpeed,
        WalkSpeed = WalkSpeed,
        PokedexExtraData = pokedexExtras.TryGetValue(Index.ToString(), out var extra) ? extra.ToOutput(Name) : throw new Exception("Extra Data not found"),
        MinimumFieldLevel = MinimumFieldLevel
    };
}