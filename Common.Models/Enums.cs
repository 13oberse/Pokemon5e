using System;

namespace Common.Models;

public enum PokemonType
{
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
    Dark,
    Steel,
    Fairy,
    Varies,
    Typeless
}

public enum PokemonMoveTime
{
    Action,
    BonusAction,
    Reaction
}

[Flags]
public enum PokemonMoveDuration
{
    Instantaneous = 0,
    Round1 = 1,
    Round2 = 2,
    Round3 = 4,
    Round5 = 8,
    Minute1 = 16,
    Minute10 = 32,
    Encounter = 64,
    Varies = 128
}

[Flags]
public enum PokemonTarget
{
    Self = 0,
    Melee = 1,
    Ranged = 2
}

public enum PokemonMoveShape
{
    Cone,
    Line,
    Radius
}

public enum PokemonGender
{
    Genderless = 0,
    Male = 1,
    Female = 2
}

[Flags]
#pragma warning disable RCS1135
public enum PokemonAbilityScore
#pragma warning restore RCS1135
{
    Strength = 1,
    Dexterity = 2,
    Constitution = 4,
    Intelligence = 8,
    Wisdom = 16,
    Charisma = 32,
    Varies = 64,
    Any = Strength | Dexterity | Constitution | Intelligence | Wisdom | Charisma
}