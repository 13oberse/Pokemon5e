using Common.Models.JsonClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Models;

public static class DefaultValues
{
    public static readonly List<string> ListStringDefault = new(0);

    public static readonly List<PokemonAbilityScore> ListPokemonAbilityScoresDefault = new(0);

    public static readonly List<PokemonAbilityScore> ListPokemonAbilityScoresAll = Enum.GetValues<PokemonAbilityScore>().Where(x => (x & PokemonAbilityScore.Any) != PokemonAbilityScore.Any).ToList();

    public static readonly List<PokemonType> ListPokemonTypeDefault = new(0);

    public static readonly List<PokemonType> ListPokemonTypeAll = Enum.GetValues<PokemonType>().Where(x => x is not PokemonType.Varies or PokemonType.Typeless).ToList();

    public static readonly Dictionary<string, int> DictionaryIntDefault = new(0);

    public static readonly Dictionary<string, List<string>> DictionaryListStringDefault = new(0);

    public static readonly Dictionary<string, PokemonJsonMoveDamage> DictionaryMoveDamageDefault = new(0);
}