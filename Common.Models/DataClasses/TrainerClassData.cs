using System.Collections.Generic;

namespace Common.Models.DataClasses;

public record TrainerClassData
{
    public string Name { get; init; } = string.Empty;

    public List<string> Pokemon { get; init; } = DefaultValues.ListStringDefault;
}