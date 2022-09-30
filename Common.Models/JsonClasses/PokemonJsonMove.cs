using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Common.Models.JsonClasses;

public record class PokemonJsonMove : IPokemonJsonType<PokemonMoveData>
{
    public Dictionary<string, PokemonJsonMoveDamage>? Damage { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Duration { get; set; } = string.Empty;

    [JsonPropertyName("Move Power")]
    public List<string>? MovePower { get; set; }

    [JsonPropertyName("Move Time")]
    public string MoveTime { get; set; } = string.Empty;

    [JsonPropertyName("PP")]
    public int PowerPoints { get; set; }

    public string Range { get; set; } = string.Empty;

    public string Scaling { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("atk")]
    public bool IsAttack { get; set; }

    public string? Save { get; set; }

    public PokemonMoveData ToOutput()
    {
        var (duration, isConcentration, isCharge) = Duration.GetMoveDuration();
        var (target, range, moveShape) = Range.GetMoveRange();
        var (moveTime, isRecharge, isCharge2) = MoveTime.GetMoveTime();
        return new PokemonMoveData
        {
            Damage = Damage,
            Description = Description,
            Duration = duration,
            MovePower = MovePower is not { Count: > 0} ? null : MovePower.ConvertAll(x => x.GetAbilityScore()),
            Save = Save?.GetAbilityScore(),
            Scaling = Scaling,
            Type = Type.GetPokemonType(),
            IsAttack = IsAttack,
            IsConcentration = isConcentration,
            MoveTime = moveTime,
            PowerPoints = PowerPoints,
            Target = target,
            Range = range,
            MoveShape = moveShape,
            IsRecharge = isRecharge,
            IsCharge = isCharge || isCharge2
        };
    }
}