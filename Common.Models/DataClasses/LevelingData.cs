namespace Common.Models.DataClasses;

public record LevelingData
{
    public int Level { get; init; }

    public int Proficiency { get; init; }

    public int SameTypeAttackBonus { get; init; }

    public int AbilityScoreIncrease { get; init; }

    public int Experience { get; init; }
}