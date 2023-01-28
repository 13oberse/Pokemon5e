using System.Collections.Generic;

namespace Common.Models.DataClasses;

public record NatureData
{
    public string Name { get; init; } = string.Empty;

    public Dictionary<string, int> AbilityScoreChanges { get; init; } = DefaultValues.DictionaryIntDefault;
}