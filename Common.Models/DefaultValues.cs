using System;
using System.Collections.Generic;
using Common.Models.JsonClasses;

namespace Common.Models;

public static class DefaultValues
{
    public static readonly List<string> ListStringDefault = new(0);

    public static readonly List<PokemonAbilityScore> ListPokemonAbilityScoresDefault = new(0);

    public static readonly PokemonAbilityScore[] ListPokemonAbilityScoresAll = Enum.GetValues<PokemonAbilityScore>();

    public static readonly List<PokemonType> ListPokemonTypeDefault = new(0);

    public static readonly PokemonType[] ListPokemonTypeAll = Enum.GetValues<PokemonType>();

    public static readonly Dictionary<string, int> DictionaryIntDefault = new(0);

    public static readonly Dictionary<string, List<string>> DictionaryListStringDefault = new(0);

    public static readonly Dictionary<string, PokemonJsonMoveDamage> DictionaryMoveDamageDefault = new(0);
}