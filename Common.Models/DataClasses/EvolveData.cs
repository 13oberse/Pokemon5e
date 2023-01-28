using System.Collections.Generic;

namespace Common.Models.DataClasses;

public record EvolveData
{
    public string Name { get; init; } = string.Empty;

    public List<string> Into { get; init; } = DefaultValues.ListStringDefault;

    public int CurrentStage { get; init; }

    public int TotalStages { get; init; }

    public int Points { get; init; }

    public int Level { get; init; }
}