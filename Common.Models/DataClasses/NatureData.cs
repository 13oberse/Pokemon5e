using System.Collections.Generic;
using System.Linq;

namespace Common.Models.DataClasses;

public record NatureData
{
    public string Name { get; init; } = string.Empty;

    public Dictionary<string, int> AbilityScoreChanges { get; init; } = DefaultValues.DictionaryIntDefault;

    public static List<NatureData> GetFromDictionary(Dictionary<string, Dictionary<string, int>> input) => input
        .Select(x => new NatureData
        {
            Name = x.Key,
            AbilityScoreChanges = x.Value
        })
        .ToList();
}