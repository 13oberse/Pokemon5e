namespace Common.Models.DataClasses;

public record MoveDamageData
{
    public int Amount { get; init; }

    public int DiceMax { get; init; }

    public bool Move { get; init; }
}