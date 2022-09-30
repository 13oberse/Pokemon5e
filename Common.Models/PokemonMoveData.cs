using Common.Models.JsonClasses;
using System.Collections.Generic;

namespace Common.Models;

public record class PokemonMoveData
{
    public Dictionary<string, PokemonJsonMoveDamage>? Damage { get; set; }

    public string Description { get; set; } = string.Empty;

    public PokemonMoveDuration Duration { get; set; }

    public List<PokemonAbilityScore>? MovePower { get; set; }

    public PokemonMoveTime MoveTime { get; set; }

    public int PowerPoints { get; set; }

    public PokemonTarget Target { get; set; }

    public int Range { get; set; }

    public string Scaling { get; set; } = string.Empty;

    public PokemonType Type { get; set; }

    public bool IsAttack { get; set; }

    public bool IsConcentration { get; set; }

    public PokemonAbilityScore? Save { get; set; }

    public PokemonMoveShape? MoveShape { get; set; }

    public bool IsRecharge { get; set; }

    public bool IsCharge { get; set; }
}