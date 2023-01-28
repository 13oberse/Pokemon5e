using System.Collections.Generic;

namespace Common.Models.DataClasses;

public record MoveData
{
    public string Name { get; init; } = string.Empty;

    public List<SerializableKeyValuePair<int, MoveDamageData>>? Damage { get; init; }

    public string Description { get; init; } = string.Empty;

    public PokemonMoveDuration Duration { get; init; }

    public List<PokemonAbilityScore>? MovePower { get; init; }

    public PokemonMoveTime MoveTime { get; init; }

    public int PowerPoints { get; init; }

    public PokemonTarget Target { get; init; }

    public int Range { get; init; }

    public string Scaling { get; init; } = string.Empty;

    public PokemonType Type { get; init; }

    public bool IsAttack { get; init; }

    public bool IsConcentration { get; init; }

    public PokemonAbilityScore? Save { get; init; }

    public PokemonMoveShape? MoveShape { get; init; }

    public bool IsRecharge { get; init; }

    public bool IsCharge { get; init; }
}