using System;
using System.Diagnostics.CodeAnalysis;

namespace Common.Models;

public static class CommonHelper
{
    public static PokemonType GetPokemonType(this string type) => type switch
    {
        nameof(PokemonType.Normal) => PokemonType.Normal,
        nameof(PokemonType.Fire) => PokemonType.Fire,
        nameof(PokemonType.Water) => PokemonType.Water,
        nameof(PokemonType.Electric) => PokemonType.Electric,
        nameof(PokemonType.Grass) => PokemonType.Grass,
        nameof(PokemonType.Ice) => PokemonType.Ice,
        nameof(PokemonType.Fighting) => PokemonType.Fighting,
        nameof(PokemonType.Poison) => PokemonType.Poison,
        nameof(PokemonType.Ground) => PokemonType.Ground,
        nameof(PokemonType.Flying) => PokemonType.Flying,
        nameof(PokemonType.Psychic) => PokemonType.Psychic,
        nameof(PokemonType.Bug) => PokemonType.Bug,
        nameof(PokemonType.Rock) => PokemonType.Rock,
        nameof(PokemonType.Ghost) => PokemonType.Ghost,
        nameof(PokemonType.Dragon) => PokemonType.Dragon,
        nameof(PokemonType.Dark) => PokemonType.Dark,
        nameof(PokemonType.Steel) => PokemonType.Steel,
        nameof(PokemonType.Fairy) => PokemonType.Fairy,
        nameof(PokemonType.Varies) => PokemonType.Varies,
        nameof(PokemonType.Typeless) => PokemonType.Typeless,
        _ => Throw<PokemonType>($"{nameof(GetPokemonType)} {type} did not map")
    };

    public static PokemonAbilityScore GetAbilityScore(this string abilityScore) => abilityScore switch
    {
        "STR" => PokemonAbilityScore.Strength,
        "DEX" => PokemonAbilityScore.Dexterity,
        "CON" => PokemonAbilityScore.Constitution,
        "INT" => PokemonAbilityScore.Intelligence,
        "WIS" => PokemonAbilityScore.Wisdom,
        "CHA" => PokemonAbilityScore.Charisma,
        "Varies" => PokemonAbilityScore.Varies,
        "Any" => PokemonAbilityScore.Any,
        _ => Throw<PokemonAbilityScore>($"{nameof(GetAbilityScore)} '{abilityScore}' did not map")
    };

    public static (PokemonMoveDuration Duration, bool IsConcentration, bool IsCharge) GetMoveDuration(this string duration) => duration switch
    {
        "Instantaneous" => (PokemonMoveDuration.Instantaneous, false, false),
        // ReSharper disable once StringLiteralTypo
        "Instataneouus" => (PokemonMoveDuration.Instantaneous, false, false),
        "1 round" => (PokemonMoveDuration.Round1, false, false),
        "1 round, charge" => (PokemonMoveDuration.Round1, false, true),
        "1 round, Concentration" => (PokemonMoveDuration.Round1, true, false),
        "2 rounds" => (PokemonMoveDuration.Round2, true, false),
        "2 turns, Concentration" => (PokemonMoveDuration.Round2, true, false),
        "2-3 rounds" => (PokemonMoveDuration.Round2 | PokemonMoveDuration.Round3, true, false),
        "3 rounds" => (PokemonMoveDuration.Round3, false, false),
        "3 rounds (Concentration)" => (PokemonMoveDuration.Round3, true, false),
        "3 rounds, Concentration" => (PokemonMoveDuration.Round3, true, false),
        "3 Rounds, Concentration" => (PokemonMoveDuration.Round3, true, false),
        "5 rounds" => (PokemonMoveDuration.Round5, false, false),
        "5 rounds, Concentration" => (PokemonMoveDuration.Round5, true, false),
        "1 minute" => (PokemonMoveDuration.Minute1, false, false),
        "1 minute, concentration" => (PokemonMoveDuration.Minute1, true, false),
        "1 minute, Concentration" => (PokemonMoveDuration.Minute1, true, false),
        "10 minutes" => (PokemonMoveDuration.Minute10, false, false),
        "While in battle" => (PokemonMoveDuration.Encounter, false, false),
        "Varies" => (PokemonMoveDuration.Varies, false, false),
        _ => Throw<(PokemonMoveDuration Duration, bool IsConcentration, bool IsCharge)>($"{nameof(GetMoveDuration)} '{duration}' did not map")
    };

    public static (PokemonTarget Target, int Range, PokemonMoveShape? MoveShape) GetMoveRange(this string range) => range switch
    {
        "Melee" => (PokemonTarget.Melee, 0, null),
        "Melee (15ft reach)" => (PokemonTarget.Melee, 15, null),
        "Melee, 20ft" => (PokemonTarget.Melee | PokemonTarget.Ranged, 20, null),
        "Melee/60ft" => (PokemonTarget.Melee | PokemonTarget.Ranged, 60, null),
        "Self" => (PokemonTarget.Self, 0, null),
        "30ft, Self" => (PokemonTarget.Self | PokemonTarget.Ranged, 30, null),
        "5ft" => (PokemonTarget.Ranged, 5, null),
        "10ft" => (PokemonTarget.Ranged, 10, null),
        "15ft" => (PokemonTarget.Ranged, 15, null),
        "20ft" => (PokemonTarget.Ranged, 20, null),
        "25ft" => (PokemonTarget.Ranged, 25, null),
        "30ft" => (PokemonTarget.Ranged, 30, null),
        "35ft" => (PokemonTarget.Ranged, 35, null),
        "40ft" => (PokemonTarget.Ranged, 40, null),
        "45ft" => (PokemonTarget.Ranged, 45, null),
        "50ft" => (PokemonTarget.Ranged, 50, null),
        "60ft" => (PokemonTarget.Ranged, 60, null),
        "80ft" => (PokemonTarget.Ranged, 80, null),
        "100ft" => (PokemonTarget.Ranged, 100, null),
        "120ft" => (PokemonTarget.Ranged, 120, null),
        "Self (15ft cone)" => (PokemonTarget.Ranged, 15, PokemonMoveShape.Cone),
        "Self (20ft cone)" => (PokemonTarget.Ranged, 20, PokemonMoveShape.Cone),
        "Self (30ft cone)" => (PokemonTarget.Ranged, 30, PokemonMoveShape.Cone),
        "Self (40ft cone)" => (PokemonTarget.Ranged, 40, PokemonMoveShape.Cone),
        "Self (60ft cone)" => (PokemonTarget.Ranged, 60, PokemonMoveShape.Cone),
        "Self (25ft line)" => (PokemonTarget.Ranged, 25, PokemonMoveShape.Line),
        "Self (40ft line)" => (PokemonTarget.Ranged, 40, PokemonMoveShape.Line),
        "Self (50ft line)" => (PokemonTarget.Ranged, 50, PokemonMoveShape.Line),
        "Self (60ft line)" => (PokemonTarget.Ranged, 60, PokemonMoveShape.Line),
        "Self (80ft line)" => (PokemonTarget.Ranged, 80, PokemonMoveShape.Line),
        "Self (100ft line)" => (PokemonTarget.Ranged, 100, PokemonMoveShape.Line),
        "Self (5ft radius)" => (PokemonTarget.Ranged, 5, PokemonMoveShape.Radius),
        "Self (10ft radius)" => (PokemonTarget.Ranged, 10, PokemonMoveShape.Radius),
        "Self (15ft radius)" => (PokemonTarget.Ranged, 15, PokemonMoveShape.Radius),
        "Self (20ft radius)" => (PokemonTarget.Ranged, 30, PokemonMoveShape.Radius),
        "Self (30ft radius)" => (PokemonTarget.Ranged, 30, PokemonMoveShape.Radius),
        "Self (40ft radius)" => (PokemonTarget.Ranged, 40, PokemonMoveShape.Radius),
        "Self (50ft radius)" => (PokemonTarget.Ranged, 50, PokemonMoveShape.Radius),
        "Self (60ft radius)" => (PokemonTarget.Ranged, 60, PokemonMoveShape.Radius),
        "Varies" => (PokemonTarget.Melee | PokemonTarget.Ranged | PokemonTarget.Self, 0, null),
        _ => Throw<(PokemonTarget Target, int Range, PokemonMoveShape? MoveShape)>($"{nameof(GetMoveRange)} '{range}' did not map")
    };

    public static (PokemonMoveTime MoveTime, bool IsRecharge, bool IsCharge) GetMoveTime(this string moveTime) => moveTime switch
    {
        "1 action" => (PokemonMoveTime.Action, false, false),
        "1 action, charge" => (PokemonMoveTime.Action, true, false),
        "1 action, recharge" => (PokemonMoveTime.Action, true, false),
        "1 bonus action" => (PokemonMoveTime.BonusAction, false, false),
        "1 reaction" => (PokemonMoveTime.Reaction, false, false),
        _ => Throw<(PokemonMoveTime MoveTime, bool IsRecharge, bool IsCharge)>($"{nameof(GetMoveTime)} '{moveTime}' did not map")
    };

    public static float GetTypeEffectiveness(PokemonType attackingType, PokemonType defendingType) => attackingType switch
    {
        PokemonType.Normal => defendingType switch
        {
            PokemonType.Ghost => PokemonConstants.IMMUNE,
            PokemonType.Rock or PokemonType.Steel => PokemonConstants.RESIST,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Fire => defendingType switch
        {
            PokemonType.Fire or PokemonType.Water or PokemonType.Rock or PokemonType.Dragon => PokemonConstants.RESIST,
            PokemonType.Grass or PokemonType.Ice or PokemonType.Bug or PokemonType.Steel => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Water => defendingType switch
        {
            PokemonType.Water or PokemonType.Grass or PokemonType.Dragon => PokemonConstants.RESIST,
            PokemonType.Fire or PokemonType.Ground or PokemonType.Rock => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Electric => defendingType switch
        {
            PokemonType.Ground => PokemonConstants.IMMUNE,
            PokemonType.Electric or PokemonType.Grass or PokemonType.Dragon => PokemonConstants.RESIST,
            PokemonType.Water or PokemonType.Flying => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Grass => defendingType switch
        {
            PokemonType.Fire or PokemonType.Grass or PokemonType.Poison or PokemonType.Flying or PokemonType.Bug or PokemonType.Dragon or PokemonType.Steel => PokemonConstants.RESIST,
            PokemonType.Water or PokemonType.Ground or PokemonType.Rock => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Ice => defendingType switch
        {
            PokemonType.Fire or PokemonType.Water or PokemonType.Ice or PokemonType.Steel => PokemonConstants.RESIST,
            PokemonType.Grass or PokemonType.Ground or PokemonType.Flying or PokemonType.Dragon => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Fighting => defendingType switch
        {
            PokemonType.Ghost => PokemonConstants.IMMUNE,
            PokemonType.Poison or PokemonType.Flying or PokemonType.Psychic or PokemonType.Bug or PokemonType.Fairy => PokemonConstants.RESIST,
            PokemonType.Normal or PokemonType.Ice or PokemonType.Rock or PokemonType.Dark or PokemonType.Steel => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Poison => defendingType switch
        {
            PokemonType.Steel => PokemonConstants.IMMUNE,
            PokemonType.Poison or PokemonType.Ground or PokemonType.Rock or PokemonType.Ghost => PokemonConstants.RESIST,
            PokemonType.Grass or PokemonType.Fairy => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Ground => defendingType switch
        {
            PokemonType.Flying => PokemonConstants.IMMUNE,
            PokemonType.Grass or PokemonType.Bug => PokemonConstants.RESIST,
            PokemonType.Fire or PokemonType.Electric or PokemonType.Poison or PokemonType.Rock or PokemonType.Steel => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Flying => defendingType switch
        {
            PokemonType.Electric or PokemonType.Rock or PokemonType.Steel => PokemonConstants.RESIST,
            PokemonType.Grass or PokemonType.Fighting or PokemonType.Bug => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Psychic => defendingType switch
        {
            PokemonType.Dark => PokemonConstants.IMMUNE,
            PokemonType.Psychic or PokemonType.Steel => PokemonConstants.RESIST,
            PokemonType.Fighting or PokemonType.Poison => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Bug => defendingType switch
        {
            PokemonType.Fire or PokemonType.Fighting or PokemonType.Poison or PokemonType.Flying or PokemonType.Ghost or PokemonType.Steel or PokemonType.Fairy => PokemonConstants.RESIST,
            PokemonType.Grass or PokemonType.Psychic or PokemonType.Dark => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Rock => defendingType switch
        {
            PokemonType.Fighting or PokemonType.Ground or PokemonType.Steel => PokemonConstants.RESIST,
            PokemonType.Fire or PokemonType.Ice or PokemonType.Flying or PokemonType.Bug => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Ghost => defendingType switch
        {
            PokemonType.Normal => PokemonConstants.IMMUNE,
            PokemonType.Dark => PokemonConstants.RESIST,
            PokemonType.Psychic or PokemonType.Ghost => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Dragon => defendingType switch
        {
            PokemonType.Fire or PokemonType.Water or PokemonType.Electric or PokemonType.Steel => PokemonConstants.RESIST,
            PokemonType.Ice or PokemonType.Rock or PokemonType.Fairy => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Dark => defendingType switch
        {
            PokemonType.Fighting or PokemonType.Dark or PokemonType.Fairy => PokemonConstants.RESIST,
            PokemonType.Psychic or PokemonType.Ghost => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Steel => defendingType switch
        {
            PokemonType.Fire or PokemonType.Water or PokemonType.Electric or PokemonType.Steel => PokemonConstants.RESIST,
            PokemonType.Ice or PokemonType.Rock or PokemonType.Fairy => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        PokemonType.Fairy => defendingType switch
        {
            PokemonType.Fire or PokemonType.Poison or PokemonType.Steel => PokemonConstants.RESIST,
            PokemonType.Fighting or PokemonType.Dragon or PokemonType.Dark => PokemonConstants.SUPER,
            _ => PokemonConstants.NORMAL
        },
        _ => Throw<float>($"invalid {nameof(attackingType)} ({attackingType}) given")
    };

    [DoesNotReturn]
    public static T Throw<T>(string message) => throw new Exception(message);
}